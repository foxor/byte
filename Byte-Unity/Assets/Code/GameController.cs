using UnityEngine;
using System;
using System.Collections;
using System.Linq;

public class GameController : MonoBehaviour {
	public static Type[] PLAYER_TYPES = new Type[] {typeof(FOOAIProvider), typeof(FOOAIProvider)};

	public CardSet[] SetsAllowed;

	protected InputProvider[] players;
	protected GameData data;
	protected int activePlayer;

	protected int winningTotal;

	public void Awake() {
		StartNewGame();
	}

	public void Start() {
		players[activePlayer].Stream(OnStream);
	}

	protected void NextPlayer() {
		activePlayer = (activePlayer + 1) % players.Count();
	}

	protected void OnStream(byte chosenCardIndex) {
		data.PickCard(chosenCardIndex, activePlayer);

		NextPlayer();
		if (data.ShouldChoose()) {
			if (data.ShouldStream()) {
				data.BufferCard();
			}
			players[activePlayer].Stream(OnStream);
		}
		else {
			GameOver();
		}
	}

	protected void GameOver() {
		winningTotal = data.players.Aggregate((acc, x) => (byte)Mathf.Max(acc, x));
		activePlayer = -1;
	}

	protected void OnFeedbackComplete() {
		NextPlayer();
		if (activePlayer < players.Count()) {
			players[activePlayer].ProvideFeedback(data.players[activePlayer] == winningTotal, OnFeedbackComplete);
		}
		else {
			StartNewGame();
			StartCoroutine(FramePause());
		}
	}

	protected IEnumerator FramePause() {
		yield return 0;
		Start();
	}

	protected void StartNewGame() {
		data = new GameData(SetsAllowed, PLAYER_TYPES.Length);
		
		int playerCount = 0;
		players = PLAYER_TYPES.Select<Type, InputProvider>(x => {
			if (x == typeof(FOOAIProvider)) {
				return new FOOAIProvider(data, playerCount++, this);
			}
			if (x == typeof(PlayerProvider)) {
				return new PlayerProvider(data, playerCount++, this);
			}
			Debug.LogError("Unfamiliar provider type requested");
			return null;
		}).ToArray();
	}
}