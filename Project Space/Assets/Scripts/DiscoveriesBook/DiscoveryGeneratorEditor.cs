#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DiscoveryGenerator))]

public class DiscoveryGeneratorEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		GUILayout.Space(15);
		DiscoveryGenerator e = (DiscoveryGenerator)target;
		if (GUILayout.Button("Generate Discovery XML"))
		{
			e.Generate();
		}
	}
}
#endif