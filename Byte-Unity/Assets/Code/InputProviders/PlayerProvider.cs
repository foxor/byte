using UnityEngine;
using System;
using System.Collections;

public class PlayerProvider : InputProvider {
	protected GameData data;
	protected int playerId;
	protected GameController controller;
	
	public PlayerProvider(GameData data, int playerId, GameController controller) {
		this.data = data;
		this.playerId = playerId;
		this.controller = controller;
	}

	public void Stream(Action<byte> onComplete) {
	}

	public void ProvideFeedback(bool won, Action onComplete) {
	}
}