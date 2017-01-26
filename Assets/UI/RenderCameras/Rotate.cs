using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float speed;
	public GameObject rotObject;

	// Update is called once per frame
	void Update () {
		Quaternion currentRot = rotObject.transform.localRotation;
		Quaternion modifier = Quaternion.Euler (0, speed * Time.deltaTime, 0);
		currentRot *= modifier;
		rotObject.transform.localRotation = currentRot;
	}
}
