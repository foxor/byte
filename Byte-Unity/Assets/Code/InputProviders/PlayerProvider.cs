using UnityEngine;
using System;
using System.Collections;

public class PlayerProvider : InputProvider {
	protected GameData data;
	protected EvaluationContext context;
	protected int playerId;
	protected GameController controller;
	
	public PlayerProvider(GameData data, EvaluationContext context, int playerId, GameController controller) {
		this.data = data;
		this.context = context;
		this.playerId = playerId;
		this.controller = controller;
	}

	public void Stream(Action<int> onComplete) {
	}
	public void Play(Action<int> onComplete) {
	}
	public void ProvideFeedback(bool won, Action onComplete) {
	}
}