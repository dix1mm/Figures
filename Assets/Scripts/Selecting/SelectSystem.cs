using UnityEngine;

public class SelectSystem : MonoBehaviour{
	private static SelectSystem _instance;
	public static SelectSystem Instance{
		get{
			if (_instance == null)
				_instance = (SelectSystem)FindObjectOfType(typeof(SelectSystem));
			return _instance;
		}
	}
	
	private ISelectable _source, _target;

	public void Select(ISelectable selected){
		if (_source == null){
			_source = selected;
			return;
		}
		_target = selected;
		execSelection();
	}
	
	private void execSelection(){
		_source.OnSource(_target);
		if (_target == null)
			return;
		_target.OnTarget(_source);
		_source = null;
		_target = null;
	}
}
