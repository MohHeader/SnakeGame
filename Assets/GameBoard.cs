﻿using UnityEngine;
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

	public void FruitEaten(){
//		(grid.GetCell (coord) as SimpleCell).CellType = SimpleCell.Type.Floor;
		SpawnFruit ();
	}

	void SpawnFruit(){
		SimpleCell randomCell = GetRandomCell ();
		int maxTries = 20;
		while (maxTries > 0 && randomCell.CellType != SimpleCell.Type.Wall && SnakeBody.parts.Select (x => x.transform.position).ToList ().ToArray ().Contains (grid.GetMap ().GetPosition (randomCell.coord))) {
			randomCell = GetRandomCell ();
			maxTries--;
		}

		randomCell.CellType = SimpleCell.Type.Fruit;

		Instantiate (FruitPrefab, grid.GetMap ().GetPosition (randomCell.coord), Quaternion.identity);
	}

	SimpleCell GetRandomCell(){
		return (SimpleCell) grid.GetCell ( new Coord(Random.Range(0, grid.GetMap().size.x), Random.Range(0, grid.GetMap().size.y )) );
	}
}
