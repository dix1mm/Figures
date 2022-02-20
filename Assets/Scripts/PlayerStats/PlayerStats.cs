using UnityEngine;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour, IPlayerStatsSetup, IPlayerStatsUsing{
	public static IPlayerStatsSetup SetupInstance;
	public static IPlayerStatsUsing UsingInstance;
	[SerializeField] private PlayerStatsUI _ui;
	private Dictionary<string, int> _stats = new Dictionary<string, int>();
	private Dictionary<string, int> _globalStats = new Dictionary<string, int>();
	
	public void Reset(){
		foreach (var stat in _stats)
			if (_globalStats.ContainsKey(stat.Key))
				_globalStats[stat.Key] = stat.Value;
		_stats = new Dictionary<string, int>();
		_ui.Reset();
	}

	public void Add(string name, int startValue, bool isGlobal){
		if (isGlobal)
			processGlobalStat(name, ref startValue);
		_stats.Add(name, startValue);
		_ui.Add(name, startValue);
	}

	public int Get(string name){
		checkStat(name);
		return _stats[name];
	}
	
	public void Set(string name, int value){
		checkStat(name);
		_stats[name] = value;
		_ui.Set(name, value);
	}
	
	private void checkStat(string name){
		if (!_stats.ContainsKey(name))
			Debug.LogError($"There is no {name} stat!");
	}
	
	private void processGlobalStat(string name, ref int startValue){
		if (!_globalStats.ContainsKey(name))
			_globalStats.Add(name, startValue);
		startValue = _globalStats[name];
	}
	
	private void Start(){
		SetupInstance = this;
		UsingInstance = this;
	}
}