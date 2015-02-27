using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class Expression : ScriptableObject {
	public string test;
	public virtual int Evaluate(){
		throw new UnityException("Unimplemented");
	}
	public virtual IEnumerable<Expression> SubExpressions(){
		throw new UnityException("Unimplemented");
	}

	public static int Depth(Expression expression) {
		return expression.SubExpressions().Select<Expression, int>(Depth).Sum();
	}
}