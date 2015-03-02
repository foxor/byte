using UnityEngine;
using System.Collections;

public class Constant : Expression {
	public int value;
	public override int Evaluate (EvaluationContext ctx)
	{
		return value;
	}
}