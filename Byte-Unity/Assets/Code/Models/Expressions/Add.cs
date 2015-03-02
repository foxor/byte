using UnityEngine;
using System.Collections;

[System.Serializable]
public class Add : InfixExpression {
	protected override int Operator (int lhs, int rhs)
	{
		return lhs + rhs;
	}
}