using UnityEngine;
using System.Collections;

public class XOr : InfixExpression {
	protected override int Operator (int lhs, int rhs)
	{
		return lhs ^ rhs;
	}
}