using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour {
	public Color Color { get; protected set;}
	void Start () {
		Color = ColorUtils.Random ();
		GetComponent<SpriteRenderer> ().color = Color;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player"){
			other.gameObject.GetComponent<Snake>().EatFruit(this);
			Destroy (gameObject);
		}
	}
}
