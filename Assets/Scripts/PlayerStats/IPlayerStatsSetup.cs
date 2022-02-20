using UnityEngine;

public interface IPlayerStatsSetup{
	void Reset();
	void Add(string name, int startValue, bool isGlobal);
}
