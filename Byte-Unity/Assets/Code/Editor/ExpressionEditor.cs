using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;

//[CustomEditor(typeof(Expression), true)]
public class ExpressionEditor : Editor {
	public override void OnInspectorGUI() {
		GUILayout.Label(target.GetType().ToString());
		if (target.GetType().IsSubclassOf(typeof(InfixExpression))) {
			DrawInfix((InfixExpression)target);
		}
	}

	private void DrawInfix(InfixExpression e) {
		//e.lhs
	}
}