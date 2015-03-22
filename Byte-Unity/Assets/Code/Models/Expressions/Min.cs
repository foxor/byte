using UnityEngine;
using System.Collections;
using System.Linq;

public class Min : Expression {
	public Expression[] arguments;
	public override byte Evaluate (EvaluationContext context)
	{
		return (byte)(Mathf.Min(arguments.Select<Expression, int>(x => x.Evaluate(context)).ToArray()));
	}

	public override bool UsesY ()
	{
		return arguments.Any(x => x.UsesY());
	}
}