using UnityEngine;
using System.Collections;

public class Symbol : Expression {
	public Symbols Target;
	public override int Evaluate (EvaluationContext ctx)
	{
		return 0;
	}
}