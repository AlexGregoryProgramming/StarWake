using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInputTest : MonoBehaviour {

	public float moveSensitivity = 3.0f;

	string P1LeftStickHorizontalAxis = "P1LeftStickHorizontal";
	string P1LeftStickVerticalAxis = "P1LeftStickVertical";

	string P2LeftStickHorizontalAxis = "P2LeftStickHorizontal";
	string P2LeftStickVerticalAxis = "P2LeftStickVertical";

	string P3LeftStickHorizontalAxis = "P3LeftStickHorizontal";
	string P3LeftStickVerticalAxis = "P3LeftStickVertical";

	string P4LeftStickHorizontalAxis = "P4LeftStickHorizontal";
	string P4LeftStickVerticalAxis = "P4LeftStickVertical";

	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	public GameObject p4;

	public float p1Angle;
	public Material red;
	public Material blue;
	public Material green;
	public Material yellow;
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
	{
		float p1h = Input.GetAxis(P1LeftStickHorizontalAxis);
		float p1v = Input.GetAxis(P1LeftStickVerticalAxis);

		float p2h = Input.GetAxis(P2LeftStickHorizontalAxis);
		float p2v = Input.GetAxis(P2LeftStickVerticalAxis);

		float p3h = Input.GetAxis(P3LeftStickHorizontalAxis);
		float p3v = Input.GetAxis(P3LeftStickVerticalAxis);

		float p4h = Input.GetAxis(P4LeftStickHorizontalAxis);
		float p4v = Input.GetAxis(P4LeftStickVerticalAxis);

		p1.transform.position += new Vector3(p1h, p1v, 0f).normalized * moveSensitivity * Time.deltaTime;
		p2.transform.position += new Vector3(p2h, p2v, 0f).normalized * moveSensitivity * Time.deltaTime;
		p3.transform.position += new Vector3(p3h, p3v, 0f).normalized * moveSensitivity * Time.deltaTime;
		p4.transform.position += new Vector3(p4h, p4v, 0f).normalized * moveSensitivity * Time.deltaTime;

		p1Angle = Mathf.Abs( Mathf.Atan2 (p1v, p1h) * Mathf.Rad2Deg - 90);

		Quaternion p1TempRotation = p1.GetComponent<Transform> ().rotation;
		p1.GetComponent<Transform> ().rotation = p1TempRotation * Quaternion.AngleAxis (p1Angle, Vector3.forward);

		


		if (Input.GetKeyDown (KeyCode.Joystick1Button0)) 
		{
			p1.GetComponent<MeshRenderer> ().material = green;
		}
		if (Input.GetKeyDown (KeyCode.Joystick1Button1)) 
		{
			p1.GetComponent<MeshRenderer> ().material = red;
		}
		if (Input.GetKeyDown (KeyCode.Joystick1Button2)) 
		{
			p1.GetComponent<MeshRenderer> ().material = blue;
		}
		if (Input.GetKeyDown (KeyCode.Joystick1Button3)) 
		{
			p1.GetComponent<MeshRenderer> ().material = yellow;
		}



		if (Input.GetKeyDown (KeyCode.Joystick2Button0)) 
		{
			p2.GetComponent<MeshRenderer> ().material = green;
		}
		if (Input.GetKeyDown (KeyCode.Joystick2Button1)) 
		{
			p2.GetComponent<MeshRenderer> ().material = red;
		}
		if (Input.GetKeyDown (KeyCode.Joystick2Button2)) 
		{
			p2.GetComponent<MeshRenderer> ().material = blue;
		}
		if (Input.GetKeyDown (KeyCode.Joystick2Button3)) 
		{
			p2.GetComponent<MeshRenderer> ().material = yellow;
		}


		if (Input.GetKeyDown (KeyCode.Joystick3Button0)) 
		{
			p3.GetComponent<MeshRenderer> ().material = green;
		}
		if (Input.GetKeyDown (KeyCode.Joystick3Button1)) 
		{
			p3.GetComponent<MeshRenderer> ().material = red;
		}
		if (Input.GetKeyDown (KeyCode.Joystick3Button2)) 
		{
			p3.GetComponent<MeshRenderer> ().material = blue;
		}
		if (Input.GetKeyDown (KeyCode.Joystick3Button3)) 
		{
			p3.GetComponent<MeshRenderer> ().material = yellow;
		}


		if (Input.GetKeyDown (KeyCode.Joystick4Button0)) 
		{
			p4.GetComponent<MeshRenderer> ().material = green;
		}
		if (Input.GetKeyDown (KeyCode.Joystick4Button1)) 
		{
			p4.GetComponent<MeshRenderer> ().material = red;
		}
		if (Input.GetKeyDown (KeyCode.Joystick4Button2)) 
		{
			p4.GetComponent<MeshRenderer> ().material = blue;
		}
		if (Input.GetKeyDown (KeyCode.Joystick4Button3)) 
		{
			p4.GetComponent<MeshRenderer> ().material = yellow;
		}

	}
}
