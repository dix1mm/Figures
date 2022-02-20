using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerStatsUI : MonoBehaviour{
	[SerializeField] private GameObject _playerStatsPanel;
	[SerializeField] private GameObject _statPrefab;
	[SerializeField] private float _offset;
	private List<Text> _texts = new List<Text>();
	
	public void Reset(){
		foreach (var item in _texts)
			Destroy(item);
		_texts = new List<Text>();
	}
	
	public void Add(string name, int value){
		Text text = Instantiate(_statPrefab, _playerStatsPanel.transform).GetComponent<Text>();
		text.name = name;
		text.transform.localPosition = new Vector2(_texts.Count * _offset, 0);
		_texts.Add(text);
		(_playerStatsPanel.transform as RectTransform).sizeDelta = new Vector2(_texts.Count * _offset, 100);//не знаю где принято хранить конфиги с размерами ui
		Set(name, value);
	}
	
	public void Set(string name, int value){
		_texts[getIndexByName(name)].text = $"{name}: {value}";
	}
	
	private int getIndexByName(string name){
		for (int i=0;i<_texts.Count;i++)
			if (_texts[i].name == name)
				return i;
		Debug.LogError($"Stat {name} not found!");
		return -1;
	}
}
