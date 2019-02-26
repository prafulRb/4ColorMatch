using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreAndUI : MonoBehaviour {
	public int scoreNum;
    int highScore;
	public Text scoreText;
    public Text highScoreText;
	public GameObject GameOverPanel;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
        highScore = PlayerPrefs.GetInt("HighScore");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IncreaseScore(){
		scoreNum++;
		scoreText.text = scoreNum.ToString ();
	}

	public void GameOver(){
        if (scoreNum > highScore) {
            highScore = scoreNum;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        highScoreText.text = "HighScore: " + highScore.ToString();
		GameOverPanel.SetActive (true);
		Time.timeScale = 0;
	}

	public void PlayAgain(){
		SceneManager.LoadScene ("MainGame");
	}
}
