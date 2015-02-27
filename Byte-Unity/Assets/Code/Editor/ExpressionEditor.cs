using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;

[CustomEditor(typeof(Expression), true)]
public class ExpressionEditor : Editor {
	public override void OnInspectorGUI() {
		GUILayout.Label(target.GetType().ToString());
		target = new Add();
	}

	private void DrawExpression() {
	}
}