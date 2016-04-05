using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public Snake Snake;

	public static GameMaster Instance;
	public GameBoard board;

	void Awake(){
		Instance = this;
	}

	public void GameOver(){
		print ("GameOver");
		Time.timeScale = 0;
		if (OnGameOver != null)
			OnGameOver ();
	}

	public void FruitEaten(){
		board.FruitEaten ();
		if(OnFruitEaten != null)
			OnFruitEaten();
	}

	public void Restart(){
		Time.timeScale = 1;
		if (OnRestart != null)
			OnRestart ();
	}

	public event System.Action OnFruitEaten;
	public event System.Action OnRestart;
	public event System.Action OnGameOver;
}
