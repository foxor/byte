using UnityEngine;
using System.Collections;

public class RollBits : Expression {
	public override byte Evaluate (EvaluationContext context) {
		return Roll();
	}

	public static byte Roll() {
		return (byte)(RollBit() + RollBit() + RollBit() + RollBit() + RollBit() + RollBit() + RollBit() + RollBit());
	}

	protected static byte RollBit() {
		return (byte)(Random.Range(0f, 1f) > 0.5f ? 1 : 0);
	}

	public override bool UsesY ()
	{
		return false;
	}
}