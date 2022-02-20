using UnityEngine;

public class Triangle : Figure{
	public override void OnSource(ISelectable target){
		if (!(target is Cube)) return;
		Cube cube = target as Cube;
		int energy = PlayerStats.UsingInstance.Get("Energy");
		if (energy <= 0) return;//не хватает энергии
		PlayerStats.UsingInstance.Set("Energy", energy-1);
		cube.Size--;//сюда еще можно добавить проверку на ненулевой размер
		Destroy(this.gameObject);
	}
}