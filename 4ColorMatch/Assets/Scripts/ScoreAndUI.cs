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
	Animator uiAnim;
	Spawn spawnScript;
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
		uiAnim = GameObject.Find ("Canvas").GetComponent<Animator> ();
		spawnScript = GameObject.Find ("GameManager").GetComponent<Spawn> ();

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
		uiAnim.SetTrigger("gameover");
		spawnScript.StopGame ();
	}

	//When Player Press Play Button
	public void Play(){
		uiAnim.SetTrigger("play");
		spawnScript.StartGame ();
	}
	//When Player Press PlayAgain Button at Gameover Scene
	public void PlayAgain(){
		uiAnim.SetTrigger ("playagain");
		spawnScript.StartGame ();
		scoreNum = 0;
		scoreText.text = scoreNum.ToString ();
	}
}
