using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(Figure), true)]
public class FigureEditor : Editor{
	private const float scaleFromSize = 0.1f;
	
	public void OnSceneGUI(){
		var t = (Figure)target;
		t.transform.localScale = new Vector3(t.Size*scaleFromSize, t.Size*scaleFromSize, 1);
	}
}