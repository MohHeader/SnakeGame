using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SnakeBodySpawner : MonoBehaviour {
	public List<SnakeFollower> parts;// { get; protected set; }
	public int InitalParts;
	 public int ToSpawn;
	public GameObject PartPrefap;
	public Transform PartsParent;

	void Start(){
		parts = new List<SnakeFollower> ();
		GameMaster.Instance.OnRestart += ResetSnakePart;
		ResetSnakePart ();	
	}

	public void UpdateStep(){
		if (ToSpawn > 0) {
			ToSpawn--;
			GameObject go = Instantiate (PartPrefap, parts.Last().LastPosition, Quaternion.identity) as GameObject;
			go.transform.SetParent (PartsParent);
			SnakeFollower sf = go.GetComponent<SnakeFollower> ();
			sf.Followed = parts.Last();
			parts.Add (sf);

			//TODO: Move From Here !
			if (sf.Followed != parts.First ())
				sf.Followed.transform.localScale = Vector3.one * 0.7f;
			sf.transform.localScale = Vector3.one * 0.5f;
		}
	}

	void ResetSnakePart(){
		foreach(Transform child in PartsParent){
			Destroy(child.gameObject);
		}
		ToSpawn = InitalParts;
		parts.Clear ();
		parts.Add (GetComponent<SnakeFollower> ());
	}
}
