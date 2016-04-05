using UnityEngine;
using System.Collections;

public class SnakeFollower : MonoBehaviour {
	[HideInInspector]
	public SnakeFollower Followed;
	[HideInInspector]
	public Vector3 LastPosition;

	void Start () {
		if (Followed == null) {
			GetComponent<SnakeMovment> ().OnMoved += OnHeadMoved;
		} else {
			Followed.OnMoved += OnFollowedMove;
		}
	}

	void OnHeadMoved(Vector3 t){
		LastPosition = t;
		if (OnMoved != null)
			OnMoved (LastPosition);
	}

	void OnFollowedMove(Vector3 t){
		LastPosition = transform.position;
		transform.position = t;

		if (OnMoved != null)
			OnMoved (LastPosition);
	}

	void OnDestroy(){
		if(Followed != null)
			Followed.OnMoved -= OnFollowedMove;
	}

	public event System.Action<Vector3> OnMoved;
}
