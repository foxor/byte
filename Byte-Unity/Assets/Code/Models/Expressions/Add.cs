using UnityEngine;
using System.Collections;

[System.Serializable]
public class Add : InfixExpression {
	protected override byte Operator (byte lhs, byte rhs)
	{
		return (byte)(lhs + rhs);
	}
}