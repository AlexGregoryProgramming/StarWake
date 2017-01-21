using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CornerCycleColor : MonoBehaviour {

	private Color[] colors;
	private int currentColor;
	private bool cyclingForward;
	private float lerper;
	private float cycleSpeed;
	private Image corner;
	public Text scoreText;
	public ParticleSystem particlesH;
	public ParticleSystem particlesV;

	public void Awake()
	{
		corner = this.GetComponent<Image> ();
	}

	public void Initialize(Color[] initial, float speed)
	{
		cycleSpeed = speed;
		SwitchColor (initial);
		//DisableParticles ();
	}

	public void DisableParticles()
	{
		particlesH.Stop ();
		particlesV.Stop ();
	}

	public void EnableParticles()
	{
		particlesH.Play ();
		particlesV.Play ();
	}


	public void Update()
	{
		lerper += cycleSpeed * Time.deltaTime;
		if (cyclingForward == true) {
			Color temp = Color.Lerp(colors [currentColor], colors[currentColor + 1], lerper);
			scoreText.color = temp;
			corner.color = temp;
			var col = particlesH.main;
			col.startColor = temp;
			col = particlesV.main;
			col.startColor = temp;
			if (lerper>=1) {
				if (currentColor == colors.Length - 2) {
					cyclingForward = false;
				}
				currentColor += 1;
				lerper=0;
			}
		} else {
			Color temp = Color.Lerp (colors [currentColor], colors[currentColor - 1], lerper);
			scoreText.color = temp;
			corner.color = temp;
			var col = particlesH.main;
			col.startColor = temp;
			col = particlesV.main;
			col.startColor  = temp;
			if (lerper>=1) {
				if (currentColor == 1) {
					cyclingForward = true;
				}
				currentColor -= 1;
				lerper=0;
			}
		}
	}

	public void Score(int score)
	{
		scoreText.text = score.ToString ();
	}

	public void SwitchColor(Color[] newList)
	{
		colors = newList;
		currentColor = 0;
		cyclingForward = true;
	}

}
