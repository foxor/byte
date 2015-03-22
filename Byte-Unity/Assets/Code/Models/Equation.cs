using System;
using System.Collections.Generic;

[Serializable]
public class Equation {
	public Symbols leftHandSide;
	public Expression rightHandSide;

	public void Execute(EvaluationContext context) {
		byte value = rightHandSide.Evaluate(context);;
		switch (leftHandSide) {
		case Symbols.x:
			context.X = value;
			break;
		case Symbols.y:
			context.Y = value;
			break;
		}
	}
}