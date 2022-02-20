using UnityEngine;

public class Cube : Figure{
	public override void OnSource(ISelectable target){
		if (!(target is Circle)) return;
		Circle circle = target as Circle;
		if (circle.Size < Size) return;
		PlayerStats.UsingInstance.Set("Moves", PlayerStats.UsingInstance.Get("Moves") + 1);
		transform.position = circle.transform.position;//перемещаемся внутрь круга
		checkVisualColliders(GetComponent<BoxCollider2D>(), circle.GetComponent<CircleCollider2D>());
	}
	
	private void checkVisualColliders(BoxCollider2D box, CircleCollider2D circle){
		float circleDiameter = circle.radius*2 * circle.transform.lossyScale.x;
		float boxSide = box.size.x * box.transform.lossyScale.x;
		float boxDiagonal = boxSide * Mathf.Sqrt(2);
		if (boxDiagonal > circleDiameter)
			Debug.Log($"Box is too big! boxDiagonal={boxDiagonal}, circleDiameter={circleDiameter}");
	}
}