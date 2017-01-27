using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndRoundTrophyRow : MonoBehaviour {

	public int numWins;
	public Image[] trophies;
	private ParticleSystem[] particles;

	// Use this for initialization
	void Start () {
		for(int i = 0; i<trophies.Length; i++)
		{
			particles [i] = trophies [i].gameObject.GetComponent<ParticleSystem> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
