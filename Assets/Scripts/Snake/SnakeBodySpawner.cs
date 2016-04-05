using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SnakeBodySpawner : MonoBehaviour {
	public List<SnakeFollower> parts { get; protected set; }
	public int InitalParts;
	public Queue<Color> ToSpawn;
	public GameObject PartPrefap;
	public Transform PartsParent;

	void Start(){
		parts = new List<SnakeFollower> ();
		ToSpawn = new Queue<Color> ();
		GameMaster.Instance.OnRestart += ResetSnakePart;
		ResetSnakePart ();	
	}

	public void UpdateStep(){
		if (ToSpawn.Count > 0) {
			Color color = ToSpawn.Dequeue ();
			
			GameObject go = Instantiate (PartPrefap, parts.Last().LastPosition, Quaternion.identity) as GameObject;
			go.transform.SetParent (PartsParent);
			SnakeFollower sf = go.GetComponent<SnakeFollower> ();
			sf.Followed = parts.Last();
			parts.Add (sf);

			//TODO: Move From Here !
			if (sf.Followed != parts.First ())
				sf.Followed.transform.localScale = Vector3.one * 0.7f;
			sf.transform.localScale = Vector3.one * 0.5f;

			go.GetComponent<SpriteRenderer> ().color = color;
		}
	}

	void ResetSnakePart(){
		foreach(Transform child in PartsParent){
			Destroy(child.gameObject);
		}
		InitalParts.Times(() => Spawn(null));
		parts.Clear ();
		parts.Add (GetComponent<SnakeFollower> ());
	}

	public void Spawn(Fruit fruit){
		Color color;
		if (fruit == null) {
			color = ColorUtils.Random ();
		} else {
			color = fruit.Color;
		}
		ToSpawn.Enqueue (color);
	}
}
