using UnityEngine;
using System.Collections;

public class SnakeCollider : MonoBehaviour {
	public enum Type{
		Fruit,
		Obstacle,
		Wall
	}

	Snake snake;
	void Awake(){
		snake = GetComponent<Snake> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Collider")
			snake.OnCollide (Type.Obstacle, other.gameObject);
		else if (other.tag == "Food") {
			snake.OnCollide (Type.Fruit, other.gameObject);
			Destroy (other.gameObject);
		}
	}
}
