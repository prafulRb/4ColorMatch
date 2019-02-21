using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	public GameObject[] ballObj;
	public Transform[] spawnPos;
	float newTime;
	public float spawnTime;
	public float minSpawnTime;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//Spawn ball at certain interval
		if ((Time.time - newTime) > spawnTime) {
			Instantiate (ballObj [Random.Range(0, ballObj.Length)], spawnPos [Random.Range(0, spawnPos.Length)].position, Quaternion.identity);
			if (spawnTime > minSpawnTime) {
				spawnTime -= 0.1f;
			}
			newTime = Time.time;
		}
	}
}
