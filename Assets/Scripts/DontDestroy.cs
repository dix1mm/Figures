using UnityEngine;

public class DontDestroy : MonoBehaviour{
	private void Start(){
		UnityEngine.Object.DontDestroyOnLoad(this);
	}
}
