using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpin : MonoBehaviour {

	public float xrot;
	public float yrot;
	public float zrot;

	// Update is called once per frame
	void Update () {
		Quaternion myRot = transform.localRotation;
		Vector3 adder = new Vector3 (xrot*Time.deltaTime, yrot*Time.deltaTime, zrot*Time.deltaTime);
		myRot *= Quaternion.Euler(adder);
		transform.localRotation = myRot;
	}
}
