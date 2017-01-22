using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PickupScript : MonoBehaviour {
	public int value;
	public float fillTime;

	public Image pickUP;
	// Use this for initialization
	void Start () 
	{
		pickUP = this.gameObject.GetComponent<Image> ();
		pickUP.fillAmount = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (pickUP.fillAmount != 1.0f) 
		{
			pickUP.fillAmount += 1 / fillTime * Time.deltaTime;
		}


	}
}
