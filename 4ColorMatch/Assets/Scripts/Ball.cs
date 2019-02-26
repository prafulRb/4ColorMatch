using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public float speed;
	public float dir;
	public float acceleration;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		speed += acceleration * Time.deltaTime;
		transform.position += new Vector3 (0, speed * dir*Time.deltaTime, 0);
	}

	void OnTriggerEnter2D(Collider2D col){
		//If color ball lands on the same color then increase score else its gameover
		if (col.gameObject.tag == this.gameObject.tag) {
			GameObject.Find ("GameManager").GetComponent<ScoreAndUI> ().IncreaseScore ();
            GameObject.Find("SoundEffect").GetComponent<Sound>().PlayEatSound();
			Destroy (this.gameObject);

		} else {
			//GameOver
			Debug.Log("GameOver");
			Camera.main.GetComponent<Animator> ().SetTrigger ("shake");
			GameObject.Find ("GameManager").GetComponent<ScoreAndUI> ().GameOver ();
            GameObject.Find("SoundEffect").GetComponent<Sound>().PlayDieSound();

            speed = 0;

		}
	}
}
