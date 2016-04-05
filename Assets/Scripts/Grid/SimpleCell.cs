using UnityEngine;
using System.Collections;

public class SimpleCell : Cell {
	public enum Type{
		Floor,
		Fruit,
		Wall
	}

	Type cellType;
	public Type CellType{
		get{ return cellType; }
		set{ cellType = value; }
	}
}
