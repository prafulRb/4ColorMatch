using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	[SerializeField]GameObject[] ballObj;
	[SerializeField]Transform[] spawnPos;
	float newTime;
	[SerializeField]float spawnTime;
	[SerializeField]float minSpawnTime;
	bool isRunning;
	// Use this for initialization
	void Start () {
		isRunning = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Spawn ball at certain interval while the interval between the spawning decreases slowly to minSpawnTime
		if ((Time.time - newTime) > spawnTime && isRunning) {
			Instantiate (ballObj [Random.Range(0, ballObj.Length)], spawnPos [Random.Range(0, spawnPos.Length)].position, Quaternion.identity);
			if (spawnTime > minSpawnTime) {
				spawnTime -= 0.1f;
			}
			newTime = Time.time;
		}
	}
	public void StopGame(){
		isRunning = false;
	}
	public void StartGame(){
		isRunning = true;
		newTime = Time.time;
		spawnTime = 3;
	}
}
