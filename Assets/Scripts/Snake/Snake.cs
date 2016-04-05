using UnityEngine;
using System.Collections;

public class Snake : Stepable {
	SnakeBodySpawner spawner;
	SnakeMovment movment;

	void Awake(){
		spawner = GetComponent<SnakeBodySpawner> ();
		movment = GetComponent<SnakeMovment> ();
	}

	public override void UpdateStep(){
		movment.UpdateStep ();
		spawner.UpdateStep ();
	}

	public void OnCollide(SnakeCollider.Type type, GameObject go){
		switch (type) {
		case SnakeCollider.Type.Obstacle:
		case SnakeCollider.Type.Wall:
			GameMaster.Instance.GameOver ();
			return;
		default:
			break;
		}
	}

	public void EatFruit(Fruit f){
		spawner.Spawn (f);
		GameMaster.Instance.FruitEaten (f);
	}
}
