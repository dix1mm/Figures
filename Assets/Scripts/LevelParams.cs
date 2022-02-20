using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public struct LevelPlayerStat{
	public string Name;
	public bool IsGlobal;
	public int StartingValue;
}

public class LevelParams : MonoBehaviour{
	public ExtensionManager ExtManager;
	public bool[] ActiveExts = new bool[]{true};//расширение base включено по умолчанию и не может быть отключено
	public List<LevelPlayerStat> LevelStats = new List<LevelPlayerStat>();
	
	private void Start(){
		PlayerStats.SetupInstance.Reset();
		foreach (var stat in LevelStats)
			PlayerStats.SetupInstance.Add(stat.Name, stat.StartingValue, stat.IsGlobal);
	}
}
