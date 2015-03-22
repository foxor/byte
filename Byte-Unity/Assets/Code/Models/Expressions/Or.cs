using UnityEngine;
using System.Collections;

public class Or : InfixExpression {
	protected override byte Operator (byte lhs, byte rhs)
	{
		return (byte)(lhs | rhs);
	}
}