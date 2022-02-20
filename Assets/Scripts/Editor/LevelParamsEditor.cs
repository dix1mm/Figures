using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System;
using System.Collections.Generic;
using System.Linq;

[CustomEditor(typeof(LevelParams))]
public class LevelParamsEditor : Editor{
	private LevelParams t;
	private int _extsCount;
	
	public void OnEnable(){
		updateInfo();
	}

	public override void OnInspectorGUI(){
		List<int> activeExtsIndexes = new List<int>();
		bool drawExtToggle(int index){
			bool result = EditorGUILayout.Toggle(t.ExtManager.Extensions[index].name, t.ActiveExts[index]);
			if (result)
				activeExtsIndexes.Add(index);
			return result;
		}
		EditorGUILayout.LabelField("Extensions:");
		EditorGUI.BeginDisabledGroup(true);
		drawExtToggle(0);//base
		EditorGUI.EndDisabledGroup();		
		for (int i=1;i<_extsCount;i++)
			t.ActiveExts[i] = drawExtToggle(i);
		
		List<SetupPlayerStat> activeStats = new List<SetupPlayerStat>();
		List<GameObject> activeFigures = new List<GameObject>();
		foreach (var index in activeExtsIndexes){
			foreach (var stat in t.ExtManager.Extensions[index].SetupStats)
				activeStats.Add(stat);
			foreach (var figure in t.ExtManager.Extensions[index].Figures)
				activeFigures.Add(figure);
		}
		foreach (var stat in activeStats)//если какого-то активного стата нет в t.LevelStats, то добавляем
			if (t.LevelStats.Where(s => s.Name == stat.Name).Count() == 0)
				t.LevelStats.Add(new LevelPlayerStat{Name = stat.Name, IsGlobal = stat.IsGlobal, StartingValue = 0});
		for (int i=t.LevelStats.Count-1;i>=0;i--)//если в t.LevelStats неактивный стат, то удаляем
			if (activeStats.Where(s => s.Name == t.LevelStats[i].Name).Count() == 0)
				t.LevelStats.RemoveAt(i);

		EditorGUILayout.Space();
		EditorGUILayout.LabelField("Player Stats:");
		for (int i=0;i<t.LevelStats.Count;i++){
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(t.LevelStats[i].Name+", "+(t.LevelStats[i].IsGlobal ? "Global" : "Local"), GUILayout.Width(100));
			LevelPlayerStat stat = t.LevelStats[i];
			stat.StartingValue = EditorGUILayout.IntField("Starting Value = ", t.LevelStats[i].StartingValue);
			t.LevelStats[i] = stat;
			EditorGUILayout.EndHorizontal();
		}

		EditorGUILayout.Space();
		EditorGUILayout.LabelField("Figures:");
		foreach (var figure in activeFigures)
			if (GUILayout.Button($"Create {figure.name}"))
				 PrefabUtility.InstantiatePrefab(figure);
		//по-хорошему надо бы удалять со сцены все недоступные префабы, но я итак уже долго с этим вожусь

		if (GUI.changed){
			updateInfo();
			EditorUtility.SetDirty(t);
			EditorSceneManager.MarkSceneDirty(t.gameObject.scene);
		}
	}
	
	private void updateInfo(){
		t = (LevelParams)target;
		_extsCount = t.ExtManager.Extensions.Length;
		if (t.ActiveExts.Length != _extsCount)
			Array.Resize(ref t.ActiveExts, _extsCount);		
	}
}