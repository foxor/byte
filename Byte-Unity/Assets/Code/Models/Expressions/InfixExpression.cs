using UnityEngine;
using System.Collections;

public abstract class InfixExpression : Expression {
	public Expression lhs;
	public Expression rhs;

	protected abstract byte Operator(byte lhs, byte rhs);

	public sealed override byte Evaluate (EvaluationContext ctx)
	{
		return Operator(lhs.Evaluate(ctx), rhs.Evaluate(ctx));
	}

	public sealed override bool UsesY ()
	{
		return lhs.UsesY() || rhs.UsesY();
	}
}