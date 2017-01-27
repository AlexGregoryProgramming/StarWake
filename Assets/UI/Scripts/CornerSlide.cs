using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CornerSlide : MonoBehaviour {

	RectTransform mytransform;
	public Vector3 endCoordinates;
	public Image centerTransparency;
	public Image cornerTransparency;
	public Image Abutton;
	public Text scoreText;
	public Text playerText;

	bool center;
	Color centerColor;
	Vector3 startCoordinates;
	float progress;
	float accel;
	bool start = true;


	public void Awake()
	{
		mytransform = this.GetComponent<RectTransform> ();
		startCoordinates = new Vector3 (mytransform.anchoredPosition3D.x, mytransform.anchoredPosition3D.y, mytransform.anchoredPosition3D.z);
		Color invis = new Color (1, 1, 1, 0);
		playerText.color = invis;
		scoreText.color = invis;
		cornerTransparency.color = invis;
		centerColor = centerTransparency.color;
		Abutton.color = invis;
		centerTransparency.color = invis;
		center = true;
		progress = 0;
	}

	public void Update()
	{
		if (start == false) {
			if (center == false) {
				accel = progress / 2;
				progress += (accel + (Time.deltaTime * 0.5f));
				if (progress >= 1) {
					progress = 1;
				}
			} else {
				progress -= Time.deltaTime * 2;
				if (progress <= 0) {
					progress = 0;
				}
			}
			mytransform.anchoredPosition3D = Vector3.Lerp (startCoordinates, endCoordinates, progress);
			playerText.color = Color.Lerp (new Color (1, 1, 1, 0), Color.white, progress);
			scoreText.color = Color.Lerp (new Color (1, 1, 1, 0), Color.white, progress);
			centerTransparency.color = Color.Lerp (centerColor, Color.black, progress);
			Abutton.color = Color.Lerp (new Color (1, 1, 1, 0.35f), new Color (1, 1, 1, 0) , progress);
		} else {
			progress += Time.deltaTime;
			centerTransparency.color = Color.Lerp (new Color (1,1,1,0), centerColor, progress);
			cornerTransparency.color = Color.Lerp (new Color (1,1,1,0), Color.white, progress);
			Abutton.color = Color.Lerp (new Color (1, 1, 1, 0), new Color (1, 1, 1, 0.35f), progress);
			if (progress >= 1) {
				start = false;
				progress = 0;
				Center ();
			}
		}
	}

	public void FadeIn()
	{
		progress = 0;
		start = true;
	}

	public void Corner()
	{
		if (center == true) {
			center = false;
			AudioManager._AUDIOMANAGER.playSound ("HighSwap");
			accel = 0;
		}
	}

	public void Center()
	{
		if (center == false) {
			AudioManager._AUDIOMANAGER.playSound ("LowSwap");
			center = true;
		}
	}
}
