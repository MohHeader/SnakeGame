using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public static GameMaster Instance;

	void Awake(){
		Instance = this;
	}

	public void GameOver(){
		Time.timeScale = 0;
		if (OnGameOver != null)
			OnGameOver ();
	}

	public void FruitEaten(Fruit food){
		if(OnFruitEaten != null)
			OnFruitEaten(food);
	}

	public void Restart(){
		Time.timeScale = 1;
		if (OnRestart != null)
			OnRestart ();
	}

	public event System.Action<Fruit> OnFruitEaten;
	public event System.Action OnRestart;
	public event System.Action OnGameOver;
}
