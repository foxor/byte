using UnityEngine;
using System.Collections;

public class EvaluationContext {
	public GameData data;

	public int XTeam;
	public int X {
		get {
			return data.players[XTeam].currency;
		}
		set {
			data.players[XTeam].currency = value;
		}
	}

	public int YTeam;
	public int Y {
		get {
			return data.players[YTeam].currency;
		}
		set {
			data.players[YTeam].currency = value;
		}
	}

	public EvaluationContext(GameData data) {
		this.data = data;
	}
}