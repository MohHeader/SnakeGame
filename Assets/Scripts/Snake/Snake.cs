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

	public void OnCollide(SnakeCollider.Type type){
		switch (type) {
		case SnakeCollider.Type.Fruit:
			spawner.ToSpawn++;
			GameMaster.Instance.SpawnFruit ();
			return;
		case SnakeCollider.Type.Obstacle:
		case SnakeCollider.Type.Wall:
			GameMaster.Instance.GameOver ();
			return;
		default:
			break;
		}
	}
}
