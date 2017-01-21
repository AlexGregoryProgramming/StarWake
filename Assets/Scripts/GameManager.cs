using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{

	public static GameManager _GAMEMANAGER = null; 

	void Awake()
	{
		//Check if instance already exists
		if (_GAMEMANAGER == null)

			//if not, set instance to this
			_GAMEMANAGER = this;

		//If instance already exists and it's not this:
		else if (_GAMEMANAGER != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	// Use this for initialization
	}


		void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
