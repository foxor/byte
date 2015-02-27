using UnityEngine;
using System.Collections;

[System.Serializable]
public class Add : Expression {
	public Expression lhs;
	public Expression rhs;

	public override int Evaluate ()
	{
		return lhs.Evaluate() + rhs.Evaluate();
	}

	public override System.Collections.Generic.IEnumerable<Expression> SubExpressions ()
	{
		yield return lhs;
		yield return rhs;
	}
}