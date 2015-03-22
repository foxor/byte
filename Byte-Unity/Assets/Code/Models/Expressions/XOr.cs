using UnityEngine;
using System.Collections;

public class XOr : InfixExpression {
	protected override byte Operator (byte lhs, byte rhs)
	{
		return (byte)(lhs ^ rhs);
	}
}