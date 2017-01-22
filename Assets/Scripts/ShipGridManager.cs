using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGridManager : MonoBehaviour {

	public DirectionalGridForce leftWake;
	public DirectionalGridForce rightWake;
	public DirectionalGridForce colorWake;

	// Use this for initialization
	void Start () {
		leftWake.m_VectorGrid = GameManager._GAMEMANAGER.gameGrid;
		rightWake.m_VectorGrid = GameManager._GAMEMANAGER.gameGrid;
		colorWake.m_VectorGrid = GameManager._GAMEMANAGER.gameGrid;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
