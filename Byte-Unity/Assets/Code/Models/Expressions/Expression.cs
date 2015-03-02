using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public abstract class Expression : ScriptableObject {
	public abstract int Evaluate(EvaluationContext context);
}