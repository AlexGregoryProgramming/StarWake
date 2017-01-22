using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class CountdownNumber
{
	public string audioCountdownNames;
	public GameObject scaler;
	public Image image;
	public Image leftBuffer;
	public Image rightBuffer;
}

public class IntroCountdown : MonoBehaviour {

	public CountdownNumber[] countdown;
	private int countdownCurrent;
	private bool transitioning;
	private bool start;
	private bool end;
	private bool final;
	public float scaleSpeed;

	private GameObject obj1;
	private Image image1;
	private Image image2;
	private Image bufferL1;
	private Image bufferL2;
	private Image bufferR1;
	private Image bufferR2;
	private GameObject obj2;

	private float timer;

	public void Start()
	{
		Color invis = new Color (1, 1, 1, 0);
		foreach (CountdownNumber num in countdown) {
			num.scaler.transform.localScale = new Vector3 (0, 0, 0);
			num.image.color = invis;
			num.leftBuffer.color = invis;
			num.rightBuffer.color = invis;
		}
		end = true;
		//HACK FOR COUNTDOWN
		Invoke ("StartCountdown", 2.0f);
		//Invoke ("StartCountdown", 15.0f);
	}

	public void StartCountdown()
	{
		//First time, set first one to object 2
		obj2 = countdown [countdownCurrent].scaler;
		obj2.transform.localScale = new Vector3 (0, 0, 0);
		image2 = countdown [countdownCurrent].image;
		bufferL2 = countdown [countdownCurrent].leftBuffer;
		bufferR2 = countdown [countdownCurrent].rightBuffer;
		obj2.SetActive (true);
		start = true;
		end = false;
		AudioManager._AUDIOMANAGER.playSound (countdown [countdownCurrent].audioCountdownNames);
	}

	public void Update()
	{
		if (end == false) {
			timer += Time.deltaTime;
			if (timer >= 1.5f) {
				timer = 0;
				if (countdownCurrent != 4) {
					NextNumber ();
				} else {
					final = true;
					end = true;
				}
			}
		}
		if (start == true) {
			obj2.transform.localScale = Vector3.MoveTowards (obj2.transform.localScale, new Vector3 (1.0f, 1.0f, 1.0f), scaleSpeed * Time.deltaTime);
			float ratio = obj2.transform.localScale.x/1;
			Color temp = new Color (image2.color.r, image2.color.g, image2.color.b, ratio);
			image2.color = temp;
			bufferL2.color = temp;
			bufferR2.color = temp;
			if (obj2.transform.localScale == new Vector3 (1.0f, 1.0f, 1.0f)) {
				start = false;
			}
		}
		if (transitioning == true) {
			obj1.transform.localScale = Vector3.MoveTowards (obj1.transform.localScale, new Vector3 (0.0f, 0.0f, 0.0f), scaleSpeed * Time.deltaTime);
			Color temp = new Color (image1.color.r, image1.color.g, image1.color.b, 1-timer);
			image1.color = temp;
			bufferL1.color = temp;
			bufferR1.color = temp;
			obj2.transform.localScale = Vector3.MoveTowards (obj2.transform.localScale, new Vector3 (1.0f, 1.0f, 1.0f), scaleSpeed * Time.deltaTime);
			//Get ratio so we can also use it for alpha.
			float ratio = obj2.transform.localScale.x/1;
			temp = new Color (image2.color.r, image2.color.g, image2.color.b, ratio);
			image2.color = temp;
			bufferL2.color = temp;
			bufferR2.color = temp;
			if (obj2.transform.localScale == new Vector3 (1.0f, 1.0f, 1.0f) && temp.a==1) {
				transitioning = false;
				obj1.SetActive (false);
			}
		}
		if (final == true) {
			obj2.transform.localScale = Vector3.MoveTowards (obj2.transform.localScale, new Vector3 (20.0f, 20.0f, 20.0f), scaleSpeed * 10 * Time.deltaTime);
			if (obj2.transform.localScale.x == 20) {
				final = false;
				EndMe ();
			}
		}
	}

	public void EndMe()
	{
		//Store for next time
		end=true;
		Color invis = new Color (1, 1, 1, 0);
		foreach (CountdownNumber num in countdown) {
			num.scaler.transform.localScale = new Vector3 (0, 0, 0);
			num.image.color = invis;
			num.leftBuffer.color = invis;
			num.rightBuffer.color = invis;
		}
		countdownCurrent = 0;
	}

	public void NextNumber()
	{
		obj1 = countdown [countdownCurrent].scaler;
		image1 = countdown [countdownCurrent].image;
		bufferL1 = countdown [countdownCurrent].leftBuffer;
		bufferR1 = countdown [countdownCurrent].rightBuffer;
		countdownCurrent += 1;
		obj2 = countdown [countdownCurrent].scaler;
		obj2.SetActive (true);
		obj2.transform.localScale = new Vector3 (0, 0, 0);
		image2 = countdown [countdownCurrent].image;
		bufferL2 = countdown [countdownCurrent].leftBuffer;
		bufferR2 = countdown [countdownCurrent].rightBuffer;
		transitioning = true;
		AudioManager._AUDIOMANAGER.playSound (countdown [countdownCurrent].audioCountdownNames);
	}
}
