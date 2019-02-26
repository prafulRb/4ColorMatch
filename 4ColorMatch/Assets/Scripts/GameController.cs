using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public float[] finalRotationZ;  //the objects needs to rotate until its angle reaches finalRotationZ
	public Vector3[] currentRotation;
	public float speed; //speed at which the object rotates
	int objNum;
	public GameObject[] RectangleObj; // All of the three rectangle objects
	// Use this for initialization
	void Start () {
		finalRotationZ = new float[3];
		currentRotation = new Vector3[3];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
            //if the raycast hit the colored triangle then rotate its parent rectangle by 90 degree
			if (hit.collider != null) {
				if(hit.collider.tag == "Red" || hit.collider.tag == "Green" || hit.collider.tag == "Blue" || hit.collider.tag == "Yellow"){

					Debug.Log("Working");
					if (hit.collider.gameObject.transform.parent.name == "Rectangle1") {
						objNum = 0;
					}else if (hit.collider.gameObject.transform.parent.name == "Rectangle2") {
						objNum = 1;
					}else if (hit.collider.gameObject.transform.parent.name == "Rectangle3") {
						objNum = 2;
					}
					currentRotation [objNum] = RectangleObj [objNum].transform.eulerAngles;
					if (((finalRotationZ[objNum] + 90) - currentRotation[objNum].z) < 180) {
						finalRotationZ[objNum] += 90;
						StartCoroutine (RotateObject (objNum));
					}
				}
			}
		}

	}

	//Animate the rotation of the object 
	IEnumerator RotateObject(int num){
		yield return new WaitForSeconds (0);
		currentRotation[num] += new Vector3(0,0,speed*Time.deltaTime);

		if (currentRotation[num].z < finalRotationZ[num]) {
			RectangleObj[num].transform.eulerAngles = currentRotation[num];
			StartCoroutine (RotateObject (num));
		} else {
			RectangleObj[num].transform.eulerAngles = new Vector3 (0, 0, finalRotationZ[num]);
			if (finalRotationZ[num] == 360) {
				RectangleObj[num].transform.eulerAngles = new Vector3 (0, 0, 0);
				finalRotationZ[num] -= 360;
			} else if (finalRotationZ[num] > 360) {
				finalRotationZ[num] -= 360;
			}
		}
	}




}
