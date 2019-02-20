using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public float finalRotationZ;
	public Vector3 currentRotation;
	public float speed;
	// Use this for initialization
	void Start () {
		finalRotationZ = transform.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			currentRotation = transform.eulerAngles;
			if (((finalRotationZ + 90) - currentRotation.z) < 180) {
				finalRotationZ += 90;
				StartCoroutine (RotateObject ());
			}
		}

	}

	IEnumerator RotateObject(){
		yield return new WaitForSeconds (0);
		currentRotation += new Vector3(0,0,speed*Time.deltaTime);

		if (currentRotation.z < finalRotationZ) {
			transform.eulerAngles = currentRotation;
			StartCoroutine (RotateObject ());
		} else {
				transform.eulerAngles = new Vector3 (0, 0, finalRotationZ);
			if (finalRotationZ == 360) {
				transform.eulerAngles = new Vector3 (0, 0, 0);
				finalRotationZ -= 360;
			} else if (finalRotationZ > 360) {
				finalRotationZ -= 360;
			}
		}
	}



}
