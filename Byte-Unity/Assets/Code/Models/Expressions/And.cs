using UnityEngine;
using System.Collections;

public class And : InfixExpression {
	protected override int Operator (int lhs, int rhs)
	{
		return lhs & rhs;
	}
}