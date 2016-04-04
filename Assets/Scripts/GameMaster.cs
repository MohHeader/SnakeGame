using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public Snake Snake;

	public static GameMaster Instance;
	public GameBoard board;
	void Awake(){
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}

	public void GameOver(){
		print ("GameOver");
		Time.timeScale = 0;
	}

	public void SpawnFruit(){
		board.SpawnFruit ();
	}
}
