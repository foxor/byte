using UnityEngine;
using System.Collections;

public class Constant : Expression {
	public byte value;
	public override byte Evaluate (EvaluationContext ctx)
	{
		return value;
	}

	public override bool UsesY ()
	{
		return false;
	}
}