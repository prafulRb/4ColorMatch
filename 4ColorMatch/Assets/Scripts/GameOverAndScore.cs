using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAndScore : MonoBehaviour {
	[SerializeField]GameObject scoreParticle;
	[SerializeField]GameObject explodeParticle;
	[SerializeField]string explodeObjName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		Vector3 particlePos = transform.GetChild (0).transform.position;
		//If color ball lands on the same color then increase score else its gameover
		if (col.gameObject.tag == this.gameObject.tag) {
			GameObject.Find ("GameManager").GetComponent<ScoreAndUI> ().IncreaseScore ();
			GameObject.Find("SoundEffect").GetComponent<Sound>().PlayEatSound();
			//Vector3 particlePos = transform.GetChild (0).transform.position;
			Instantiate (scoreParticle, particlePos, Quaternion.identity);
			Destroy (this.gameObject);


		} else {
			//GameOver
			Debug.Log("GameOver");
			Camera.main.GetComponent<Animator> ().SetTrigger ("shake");
			GameObject.Find ("GameManager").GetComponent<ScoreAndUI> ().GameOver ();
			GameObject.Find ("GameManager").GetComponent<Spawn> ().StopGame ();
			GameObject.Find("SoundEffect").GetComponent<Sound>().PlayDieSound();
			explodeParticle = GameObject.Find(explodeObjName);
			explodeParticle.transform.position = particlePos;
			explodeParticle.GetComponent<ParticleSystem> ().Play ();
			Destroy (this.gameObject);

		}
	}
}
