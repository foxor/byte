using UnityEngine;
using System.Collections;

public class EvaluationContext {
	public GameData data;

	public int XTeam;
	public byte X {
		get {
			return data.players[XTeam];
		}
		set {
			data.players[XTeam] = value;
		}
	}

	public int YTeam;
	public byte Y {
		get {
			return data.players[YTeam];
		}
		set {
			data.players[YTeam] = value;
		}
	}

	public EvaluationContext(GameData data) {
		this.data = data;
	}
}