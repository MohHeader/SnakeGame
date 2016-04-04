using UnityEngine;
using System.Collections;

public class StepTimer : MonoBehaviour {
	public float StepTime = 0.5f;
	float timer = 0;

	Stepable[] items;

	void Awake(){
		items = GameObject.FindObjectsOfType<Stepable> ();
	}

	void Update(){
		timer += Time.deltaTime;
		if (timer >= StepTime) {
			timer = 0;
			UpdateStep ();
		}
	}

	void UpdateStep(){
		foreach (var item in items) {
			item.UpdateStep ();
		}
	}
}
