using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreAndUI : MonoBehaviour {
	[SerializeField]int scoreNum;
    int highScore;
	[SerializeField]Text scoreText;
	[SerializeField]Text highScoreText;
	[SerializeField]GameObject GameOverPanel;
    // Use this for initialization
    private void Awake()
    {
            //Set screen size for Standalone
        #if UNITY_STANDALONE
                Screen.SetResolution(376, 640, false);
                Screen.fullScreen = false;
        #endif
    }
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
	}

	public void PlayAgain(){
		SceneManager.LoadScene ("MainGame");
	}
}
