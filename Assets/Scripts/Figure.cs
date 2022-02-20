using UnityEngine;

public abstract class Figure : MonoBehaviour, ISelectable{
	public int Size;
	
	private void OnMouseUp() => SelectSystem.Instance.Select(this);
	public virtual void OnSource(ISelectable target){}
	public virtual void OnTarget(ISelectable source){}
	
	private void Update(){
		//дублирование Editor, но мне кажется это лучше чем связывать их с рантаймом общей логикой
		const float scaleFromSize = 0.1f;
		transform.localScale = new Vector3(Size*scaleFromSize, Size*scaleFromSize, 1);
	}
}
