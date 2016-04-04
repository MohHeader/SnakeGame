using UnityEngine;
using System.Collections;
using System.Linq;

public class GameBoard : MonoBehaviour {
	public GameObject FruitPrefab;
	public SnakeBodySpawner SnakeBody;

	CellsGrid grid;
	void Awake(){
		grid = GetComponentInChildren<CellsGrid> ();
	}

	void Start(){
		SpawnFruit ();
	}

	public void SpawnFruit(){
		Cell randomCell = grid.GetCell ( new Coord(Random.Range(0, grid.GetMap().size.x), Random.Range(0, grid.GetMap().size.y )) );
		int maxTries = 20;
		while (maxTries > 0 && SnakeBody.parts.Select (x => x.transform.position).ToList ().ToArray ().Contains (grid.GetMap ().GetPosition (randomCell.coord))) {
			randomCell = grid.GetCell ( new Coord(Random.Range(0, grid.GetMap().size.x), Random.Range(0, grid.GetMap().size.y )) );
			maxTries--;
		}

		Instantiate (FruitPrefab, grid.GetMap ().GetPosition (randomCell.coord), Quaternion.identity);
	}
}
