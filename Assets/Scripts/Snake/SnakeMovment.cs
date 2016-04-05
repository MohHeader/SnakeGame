using UnityEngine;
using System.Collections.Generic;

public class SnakeMovment : MonoBehaviour {
	public GridMap2D grid;
	Coord cPosition;
	Coord direction = new Coord(0,0);

	public Queue<Coord> DirectionList = new Queue<Coord>();

	void Start () {
		ResetSnake ();
		GameMaster.Instance.OnRestart += ResetSnake;
	}

	void ResetSnake(){
		MoveTo(new Coord(grid.size.x/2,grid.size.y/2));
		SetDirection (new Coord[]{Coord.up, Coord.down, Coord.left, Coord.right}[Random.Range(0,4)]);
	}

	public void UpdateStep(){
		if (DirectionList.Count > 0) {
			Coord dir = DirectionList.Dequeue ();
			if ((direction + dir).x != 0 || (direction + dir).y != 0) {
				direction = dir;
			}
		}
		MoveBy (direction);
	}

	void MoveBy(Coord coord){
		MoveTo (cPosition + coord);
	}

	public void MoveTo(Coord coord){
		if (grid.Contains (coord) == false) {
			GameMaster.Instance.GameOver ();
			return;
		}
		cPosition = coord;

		Vector3 old_position = transform.position;
		transform.position =  grid.GetPosition (coord);
		if (OnMoved != null)
			OnMoved (old_position);
	}

	public void SetDirection(Coord dir){
		if(Mathf.Abs (dir.x + dir.y) == 1)
			DirectionList.Enqueue (dir);
	}

	public event System.Action<Vector3> OnMoved;
}
