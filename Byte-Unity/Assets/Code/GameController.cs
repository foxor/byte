using UnityEngine;
using System;
using System.Collections;
using System.Linq;

public class GameController : MonoBehaviour {
	public static Type[] PLAYER_TYPES = new Type[] {typeof(AIProvider), typeof(AIProvider)};

	public CardSet[] SetsAllowed;

	protected InputProvider[] players;
	protected GameData data;
	protected EvaluationContext context;
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

	protected void OnStream(int chosenCardIndex) {
		data.PickCard(chosenCardIndex, activePlayer);

		NextPlayer();
		if (data.ShouldChoose()) {
			if (data.ShouldStream()) {
				data.BufferCard();
			}
			players[activePlayer].Stream(OnStream);
		}
		else {
			players[activePlayer].Play(OnPlay);
		}
	}

	protected void OnPlay(int chosenCardIndex) {
		Card chosen = data.players[activePlayer].hand[chosenCardIndex];
		data.players[activePlayer].hand.Remove(chosen);
		foreach (Equation e in chosen.equations) {
			e.Execute(context);
		}

		if (data.players.Any(x => x.hand.Count > 0)) {
			do {
				NextPlayer();
			} while (data.players[activePlayer].hand.Count == 0);
			players[activePlayer].Play(OnPlay);
		}
		else {
			GameOver();
		}
	}

	protected void GameOver() {
		winningTotal = data.players.Select<PlayerData, int>(x => x.currency).Aggregate((acc, x) => Mathf.Max(acc, x));
		activePlayer = -1;
	}

	protected void OnFeedbackComplete() {
		NextPlayer();
		if (activePlayer < players.Count()) {
			players[activePlayer].ProvideFeedback(data.players[activePlayer].currency == winningTotal, OnFeedbackComplete);
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
		context = new EvaluationContext(data);
		
		int playerCount = 0;
		players = PLAYER_TYPES.Select<Type, InputProvider>(x => {
			if (x == typeof(AIProvider)) {
				return new AIProvider(data, context, playerCount++, this);
			}
			if (x == typeof(PlayerProvider)) {
				return new PlayerProvider(data, context, playerCount++, this);
			}
			Debug.LogError("Unfamiliar provider type requested");
			return null;
		}).ToArray();
	}
}