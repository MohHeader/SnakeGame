using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SnakeBodySpawner : MonoBehaviour {
	public List<SnakeFollower> parts { get; protected set; }
	public int ToSpawn;
	public GameObject PartPrefap;

	void Awake(){
		parts = new List<SnakeFollower> ();
		parts.Add (GetComponent<SnakeFollower> ());
	}

	public void UpdateStep(){
		if (ToSpawn > 0) {
			ToSpawn--;
			GameObject go = Instantiate (PartPrefap, parts.Last().LastPosition, Quaternion.identity) as GameObject;
			SnakeFollower sf = go.GetComponent<SnakeFollower> ();
			sf.Followed = parts.Last();
			parts.Add (sf);

			//TODO: Move From Here !
			if (sf.Followed != parts.First ())
				sf.Followed.transform.localScale = Vector3.one * 0.7f;
			sf.transform.localScale = Vector3.one * 0.5f;
		}
	}
}
