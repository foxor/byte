using UnityEngine;
using System.Collections;

public class RollBits : Expression {
	public override int Evaluate (EvaluationContext context)
	{
		return RollBit() + RollBit() + RollBit() + RollBit() + RollBit() + RollBit() + RollBit() + RollBit();
	}

	protected static int RollBit() {
		return Random.Range(0f, 1f) > 0.5f ? 1 : 0;
	}
}