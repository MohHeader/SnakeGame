using UnityEngine;
using System.Collections;

public class ObstaclesMaster : MonoBehaviour {
	public Coord[] Places;
	public CellsGrid grid;
	public GameObject ObstaclePrefab;

	void Start(){
		foreach (Coord place in Places) {
			if(grid.GetMap().Contains(place)){
				SimpleCell cell = (SimpleCell) grid.GetCell (place);
				cell.CellType = SimpleCell.Type.Wall;
				Instantiate(ObstaclePrefab, grid.GetMap().GetPosition(place), Quaternion.identity);
			}
		}
	}
}
