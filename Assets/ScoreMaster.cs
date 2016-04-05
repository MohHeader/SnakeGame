using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreMaster : MonoBehaviour {
	public Text ScoreText;
	public Text HiScoreText;

	int score;

	void Start(){
		ResetScore ();
		GameMaster.Instance.OnFruitEaten += AddScore;
		GameMaster.Instance.OnRestart += ResetScore;
	}

	void AddScore(){
		SetScore (score + 1);
	}

	void SetScore(int _score){
		score = _score;
		ScoreText.text = score.ToString ();
		PlayerPrefs.SetInt ("HighScore", Mathf.Max(PlayerPrefs.GetInt("HighScore", 0), score));
	}

	public void ResetScore(){
		SetScore (0);
		HiScoreText.text = "H: " + PlayerPrefs.GetInt("HighScore", 0);
	}
}
