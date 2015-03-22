using UnityEngine;
using System.Collections;

public class Subtract : InfixExpression {
	protected override byte Operator (byte lhs, byte rhs)
	{
		return (byte)(lhs - rhs);
	}
}