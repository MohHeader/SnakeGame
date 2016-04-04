using UnityEngine;
using System.Collections;

public class SnakeController : MonoBehaviour {
	SnakeMovment movment;
	void Awake(){
		movment = GetComponent<SnakeMovment> ();
		Lean.LeanTouch.OnFingerSwipe += OnFingerSwipe;
	}

	public void OnFingerSwipe(Lean.LeanFinger finger)
	{
		// Store the swipe delta in a temp variable
		var swipe = finger.SwipeDelta;

		if (swipe.x < -Mathf.Abs(swipe.y))
		{
			movment.SetDirection(Coord.left);
		}

		if (swipe.x > Mathf.Abs(swipe.y))
		{
			movment.SetDirection(Coord.right);
		}

		if (swipe.y < -Mathf.Abs(swipe.x))
		{
			movment.SetDirection(Coord.down);
		}

		if (swipe.y > Mathf.Abs(swipe.x))
		{
			movment.SetDirection(Coord.up);
		}
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.DownArrow))
			movment.SetDirection(Coord.down);

		if(Input.GetKeyDown(KeyCode.UpArrow))
			movment.SetDirection(Coord.up);

		if(Input.GetKeyDown(KeyCode.LeftArrow))
			movment.SetDirection(Coord.left);

		if(Input.GetKeyDown(KeyCode.RightArrow))
			movment.SetDirection(Coord.right);
	}
}
