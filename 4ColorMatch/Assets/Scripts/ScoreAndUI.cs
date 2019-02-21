﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreAndUI : MonoBehaviour {
	public int scoreNum;
	public Text scoreText;
	public GameObject GameOverPanel;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IncreaseScore(){
		scoreNum++;
		scoreText.text = scoreNum.ToString ();
	}

	public void GameOver(){
		GameOverPanel.SetActive (true);
		Time.timeScale = 0;
	}

	public void PlayAgain(){
		SceneManager.LoadScene ("MainGame");
	}
}
