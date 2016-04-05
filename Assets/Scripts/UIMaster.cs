using UnityEngine;
using System.Collections;

public class UIMaster : MonoBehaviour {
	public GameObject GameOverUI;
	// Use this for initialization
	void Start () {
		GameOverUI.SetActive (false);
		GameMaster.Instance.OnRestart += delegate() {
			GameOverUI.SetActive(false);
		};
		GameMaster.Instance.OnGameOver += delegate() {
			GameOverUI.SetActive(true);
		};
	}
}
