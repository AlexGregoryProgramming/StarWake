using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyExplode : MonoBehaviour {

	public Image[] trophyImages;
	public Color og;

	public float time;
	public bool exploding;

	public void Awake()
	{
		og = trophyImages [0].color;
		foreach (Image trophy in trophyImages) {
			trophy.color = new Color (0, 0, 0, 0);
		}
	}

	public void Update()
	{
		if (exploding == true) {
			if (time < 1f) {
				time += Time.deltaTime;
				foreach (Image trophy in trophyImages) {
					trophy.color = Color.Lerp(new Color(og.r, og.g, og.b, 0.01f), new Color(og.r, og.g, og.b, 0.2f), time);
					float ran = Random.Range (0.7f, 1.2f);
					trophy.rectTransform.localScale = Vector3.Lerp (trophy.rectTransform.localScale, new Vector3(ran, ran, ran), time);
				}
				if (time >= 1f) {
					exploding = false;
					TurnOffTrophies ();
				}
			}
		}
	}

	public void Explode()
	{
		exploding = true;
		foreach (Image trophy in trophyImages) {
			trophy.color = og;
		}
		AudioManager._AUDIOMANAGER.playSound("Explosion");
	}


	public void TurnOffTrophies()
	{
		foreach (Image trophy in trophyImages) {
			trophy.color = new Color (0, 0, 0, 0);
		}
		trophyImages [0].color = og;
		trophyImages [0].rectTransform.localScale = new Vector3 (1, 1, 1);
	}

	public void ResetForWin(Color newCol, float delay)
	{
		og = newCol;
		foreach (Image trophy in trophyImages) {
			trophy.color = new Color (0, 0, 0, 0);
			trophy.rectTransform.localScale=new Vector3(1,1,1);
		}
		Invoke ("Explode", delay);
	}

}
