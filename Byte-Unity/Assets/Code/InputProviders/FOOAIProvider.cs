using UnityEngine;
using System;
using System.Collections;

// First order optimal ai provider simply picks the best option at this instant in time.
public class FOOAIProvider : InputProvider {
	protected GameData data;
	protected int playerId;
	protected GameController controller;

	public FOOAIProvider(GameData data, int playerId, GameController controller) {
		this.data = data;
		this.playerId = playerId;
		this.controller = controller;
	}

	public void Stream(Action<byte> onComplete) {
		onComplete(0);
	}

	public void ProvideFeedback(bool won, Action onComplete) {
		onComplete();
	}
}