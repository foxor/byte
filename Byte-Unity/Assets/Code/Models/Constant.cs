using UnityEngine;
using System.Collections;

[System.Serializable]
public class Constant : Expression {
	public int value;
	public override int Evaluate ()
	{
		return value;
	}

	public override System.Collections.Generic.IEnumerable<Expression> SubExpressions ()
	{
		yield break;
	}
}