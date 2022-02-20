using UnityEngine;
using System;

[Serializable]
public struct SetupPlayerStat{
	public string Name;
	public bool IsGlobal;
}

[CreateAssetMenu(fileName = "NewExtension", menuName = "Extension")]
public class Extension : ScriptableObject{
	public GameObject[] Figures;
	public SetupPlayerStat[] SetupStats;
}