using UnityEngine;
using System.Collections;

public class Symbol : Expression {
	public Symbols Target;
	public override byte Evaluate (EvaluationContext ctx)
	{
		switch (Target) {
		case Symbols.x:
			return ctx.X;
		case Symbols.y:
			return ctx.Y;
		}
		Debug.LogError("Fell through in finding a symbol");
		return 0;
	}

	public override bool UsesY ()
	{
		return Target == Symbols.y;
	}
}