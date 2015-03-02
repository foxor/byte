using UnityEngine;
using System;
using System.Collections;

public class AIProvider : InputProvider {
	protected GameData data;
	protected EvaluationContext context;
	protected int playerId;
	protected GameController controller;

	public AIProvider(GameData data, EvaluationContext context, int playerId, GameController controller) {
		this.data = data;
		this.context = context;
		this.playerId = playerId;
		this.controller = controller;
	}

	public void Stream(Action<int> onComplete) {
		onComplete(0);
	}

	public void Play(Action<int> onComplete) {
		onComplete(0);
	}

	public void ProvideFeedback(bool won, Action onComplete) {
		onComplete();
	}
}