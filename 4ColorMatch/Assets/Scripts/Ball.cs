using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	[SerializeField]float speed;
	[SerializeField]float dir;
	[SerializeField]float acceleration;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		speed += acceleration * Time.deltaTime;
		transform.position += new Vector3 (0, speed * dir*Time.deltaTime, 0);
	}


}
