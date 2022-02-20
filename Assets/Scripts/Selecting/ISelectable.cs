using UnityEngine;

public interface ISelectable{
	void OnSource(ISelectable target);
	void OnTarget(ISelectable source);
}
