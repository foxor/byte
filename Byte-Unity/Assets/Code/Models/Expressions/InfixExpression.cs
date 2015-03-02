using UnityEngine;
using System.Collections;

public abstract class InfixExpression : Expression {
	public Expression lhs;
	public Expression rhs;

	protected abstract int Operator(int lhs, int rhs);

	public sealed override int Evaluate (EvaluationContext ctx)
	{
		return Operator(lhs.Evaluate(ctx), rhs.Evaluate(ctx));
	}

	public sealed override bool UsesY ()
	{
		return lhs.UsesY() || rhs.UsesY();
	}
}