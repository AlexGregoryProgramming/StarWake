using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndRoundTrophyRow : MonoBehaviour {

	public int numWins=0;
	public Image[] trophiesGrey;
	public TrophyExplode[] trophiesLit;

	// Use this for initialization
	void Start () {
		for(int i = 0; i<trophiesGrey.Length; i++)
		{
			trophiesLit [i] = trophiesGrey [i].gameObject.GetComponentInChildren<TrophyExplode> ();
		}
	}

	public void TurnOffTrophiesNotInUse(int numUsed)
	{
		if (numUsed < 4) {
			trophiesGrey [3].gameObject.SetActive (false);
		}
		if (numUsed < 3) {
			trophiesGrey [2].gameObject.SetActive (false);
		}
		if (numUsed < 2) {
			trophiesGrey [1].gameObject.SetActive (false);
		}
	}

	public void AwardATrophy()
	{
		trophiesLit [numWins].Explode ();
		numWins += 1;
	}

	public void Winner(Color newCol)
	{
		float delay = 0.25f;
		for(int i = 0; i<trophiesGrey.Length; i++)
		{
			trophiesLit[i].ResetForWin (newCol, delay);
			delay += 0.33f;
		}
	}
}
