using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class CardEditor : EditorWindow {
	protected static Type[] ExpressionTypes = EnumerateExpressionTypes().ToArray();

	[MenuItem("Byte/Create Card Set")]
	public static void CreateSet() {
		ScriptableObject so = ScriptableObject.CreateInstance<CardSet>();
		AssetDatabase.CreateAsset(so, "Assets/Resources/Data/Card Sets/New Set.asset");
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = so;
	}

	[MenuItem("Byte/Create Expression")]
	public static void ShowWindow() {
		EditorWindow.GetWindow<CardEditor>().Show();
	}

	protected int typeIndex;
	protected string expressionName;

	protected static IEnumerable<System.Type> EnumerateExpressionTypes() {
		foreach (System.Reflection.Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
			foreach (Type t in assembly.GetTypes()) {
				if (typeof(Expression).IsAssignableFrom(t) && !t.IsAbstract) {
					yield return t;
				}
			}
		}
	}

	public void OnGUI() {
		expressionName = EditorGUILayout.TextArea(expressionName);

		GUILayout.BeginHorizontal();
		GUILayout.Label("Type: ");
		typeIndex = EditorGUILayout.Popup(typeIndex, ExpressionTypes.Select<Type, string>(x => x.ToString()).ToArray());
		GUILayout.EndHorizontal();

		if (GUILayout.Button("Create")) {
			ScriptableObject so = ScriptableObject.CreateInstance(ExpressionTypes[typeIndex]);
			AssetDatabase.CreateAsset(so, "Assets/Resources/Data/Expressions/" + expressionName + ".asset");
			AssetDatabase.SaveAssets();
			EditorUtility.FocusProjectWindow();
			Selection.activeObject = so;
		}
	}
}