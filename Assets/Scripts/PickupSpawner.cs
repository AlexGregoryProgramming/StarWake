using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour 
{

	public GameObject pickup12;
	public GameObject pickup24;
	public GameObject pickup48;
	public GameObject pickup144;

	private GameObject tempPoint;
	private int roll;
	public float timeLeft;
	public float nextSpawnTime;
	public float spawnInterval = 1;
	public GameObject[] spawnerArray;
	// Use this for initialization
	void Start () 
	{
		timeLeft = 36;

	}
	
	// Update is called once per frame
	void Update () 
	{
		timeLeft -= Time.deltaTime;
		if (timeLeft < nextSpawnTime && timeLeft < 30 && timeLeft > 0) 
		{
			nextSpawnTime -= spawnInterval;
			GameObject tempPoint = spawnerArray [Random.Range (0, spawnerArray.Length)];
			roll = Random.Range (1, 101);

			if (roll <= 40) 
			{
				Instantiate (pickup12, tempPoint.GetComponent<Transform> ().position, tempPoint.GetComponent<Transform> ().rotation);
			}

			if (roll > 40 && roll <= 70) 
			{
				Instantiate (pickup24, tempPoint.GetComponent<Transform> ().position, tempPoint.GetComponent<Transform> ().rotation);
			}

			if (roll > 70 && roll <= 90) 
			{
				Instantiate (pickup48, tempPoint.GetComponent<Transform> ().position, tempPoint.GetComponent<Transform> ().rotation);
			}

			if (roll > 90) 
			{
				Instantiate (pickup144, tempPoint.GetComponent<Transform> ().position, tempPoint.GetComponent<Transform> ().rotation);
			}
		}
	}
}