using UnityEditor;
using UnityEngine;
using System.Collections;

public class CardEditor : EditorWindow {
	protected static string[] Factions = {"Black", "Grey", "Yellow", "Green", "Blue", "White", "Red", "Purple", "Brown", "Shared"};

	[MenuItem("Byte/Create Card Set")]
	public static void CreateSet() {
		ScriptableObject so = ScriptableObject.CreateInstance<CardSet>();
		AssetDatabase.CreateAsset(so, "Assets/Resources/Data/Card Sets/New Set.asset");
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = so;
	}

	[MenuItem("Byte/Expression Editor")]
	public static void ShowWindow() {
		EditorWindow.GetWindow<CardEditor>().Show();
	}

	protected int faction;
	protected string expressionName;

	protected void Load() {
	}

	protected void Save() {
	}

	public void OnGUI() {
		faction = EditorGUILayout.Popup(faction, Factions);
		expressionName = EditorGUILayout.TextArea(expressionName);
		if (GUILayout.Button("Create")) {
			ScriptableObject so = ScriptableObject.CreateInstance<Expression>();
			AssetDatabase.CreateAsset(so, "Assets/Resources/Data/Cards/" + Factions[faction] + "/" + expressionName + ".asset");
			AssetDatabase.SaveAssets();
			EditorUtility.FocusProjectWindow();
			Selection.activeObject = so;
		}
	}
}