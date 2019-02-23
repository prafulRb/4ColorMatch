using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public float speed;
	public float dir;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (0, speed * dir*Time.deltaTime, 0);
	}

	void OnTriggerEnter2D(Collider2D col){
		
		if (col.gameObject.tag == this.gameObject.tag) {
			GameObject.Find ("GameManager").GetComponent<ScoreAndUI> ().IncreaseScore ();
			Destroy (this.gameObject);

		} else {
			//GameOver
			Debug.Log("GameOver");
			Camera.main.GetComponent<Animator> ().SetTrigger ("shake");
			GameObject.Find ("GameManager").GetComponent<ScoreAndUI> ().GameOver ();
			speed = 0;

		}
	}
}
