using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{

	public GameObject pickup12;
	public GameObject pickup24;
	public GameObject pickup48;
	public GameObject pickup144;


	private int roll;

	public int twoOrThree;

	private int startPlace;
	private int secondPlace;
	private int thirdPlace;

	private GameObject firstPoint;
	private GameObject secondPoint;
	private GameObject thirdPoint;
	public float timeLeft;
	public float nextSpawnTime;
	public float spawnInterval = 4;
	public GameObject[] spawnerArray;
	// Use this for initialization
	void Start ()
	{
		timeLeft = 53;

	}

	// Update is called once per frame
	void Update ()
	{
		timeLeft -= Time.deltaTime;
		if (timeLeft < nextSpawnTime && timeLeft < 45 && timeLeft > 0)
		{
			nextSpawnTime -= spawnInterval;
			roll = Random.Range (0, 101);
			twoOrThree = Random.Range (2, 4);

			if (roll <= 20)
			{
				startPlace = Random.Range (0, 24);
				firstPoint = spawnerArray [startPlace];
				Instantiate (pickup12, firstPoint.GetComponent<Transform> ().position, firstPoint.GetComponent<Transform> ().rotation);
			}

			if (roll > 20 && roll <= 35)
			{
				startPlace = Random.Range (0, 24);
				firstPoint = spawnerArray [startPlace];
				Instantiate (pickup24, firstPoint.GetComponent<Transform> ().position, firstPoint.GetComponent<Transform> ().rotation);
			}

			if (roll > 35 && roll <= 45)
			{
				startPlace = Random.Range (0, 24);
				firstPoint = spawnerArray [startPlace];
				Instantiate (pickup48, firstPoint.GetComponent<Transform> ().position, firstPoint.GetComponent<Transform> ().rotation);
			}

			if (roll > 45 && roll <= 50)
			{
				startPlace = Random.Range (0, 24);
				firstPoint = spawnerArray [startPlace];
				Instantiate (pickup144, firstPoint.GetComponent<Transform> ().position, firstPoint.GetComponent<Transform> ().rotation);
			}

			if (roll > 50 && roll <= 70)
			{
				if (twoOrThree == 2)
				{
					startPlace = Random.Range (0, 10);
					secondPlace = Random.Range (14, 24);

					firstPoint = spawnerArray [startPlace];
					secondPoint = spawnerArray [secondPlace];

					Instantiate (pickup12, firstPoint.GetComponent<Transform> ().position, firstPoint.GetComponent<Transform> ().rotation);
					Instantiate (pickup12, secondPoint.GetComponent<Transform> ().position, secondPoint.GetComponent<Transform> ().rotation);
				}

				if (twoOrThree == 3)
				{
					startPlace = Random.Range (0, 10);
					secondPlace = startPlace + Random.Range (4, 7);
					thirdPlace = secondPlace + Random.Range (4, 7);

					firstPoint = spawnerArray [startPlace];
					secondPoint = spawnerArray [secondPlace];
					thirdPoint = spawnerArray [thirdPlace];

					Instantiate (pickup12, firstPoint.GetComponent<Transform> ().position, firstPoint.GetComponent<Transform> ().rotation);
					Instantiate (pickup12, secondPoint.GetComponent<Transform> ().position, secondPoint.GetComponent<Transform> ().rotation);
					Instantiate (pickup12, thirdPoint.GetComponent<Transform> ().position, thirdPoint.GetComponent<Transform> ().rotation);
				}
			}

			if (roll > 70 && roll <= 85)
			{
				if (twoOrThree == 2)
				{
					startPlace = Random.Range (0, 10);
					secondPlace = Random.Range (14, 24);

					firstPoint = spawnerArray [startPlace];
					secondPoint = spawnerArray [secondPlace];

					Instantiate (pickup24, firstPoint.GetComponent<Transform> ().position, firstPoint.GetComponent<Transform> ().rotation);
					Instantiate (pickup24, secondPoint.GetComponent<Transform> ().position, secondPoint.GetComponent<Transform> ().rotation);
				}

				if (twoOrThree == 3)
				{
					startPlace = Random.Range (0, 10);
					secondPlace = startPlace + Random.Range (4, 7);
					thirdPlace = secondPlace + Random.Range (4, 7);

					firstPoint = spawnerArray [startPlace];
					secondPoint = spawnerArray [secondPlace];
					thirdPoint = spawnerArray [thirdPlace];

					Instantiate (pickup24, firstPoint.GetComponent<Transform> ().position, firstPoint.GetComponent<Transform> ().rotation);
					Instantiate (pickup24, secondPoint.GetComponent<Transform> ().position, secondPoint.GetComponent<Transform> ().rotation);
					Instantiate (pickup24, thirdPoint.GetComponent<Transform> ().position, thirdPoint.GetComponent<Transform> ().rotation);
				}
			}

			if (roll > 85 && roll <= 95)
			{
				if (twoOrThree == 2)
				{
					startPlace = Random.Range (0, 10);
					secondPlace = Random.Range (14, 24);

					firstPoint = spawnerArray [startPlace];
					secondPoint = spawnerArray [secondPlace];

					Instantiate (pickup48, firstPoint.GetComponent<Transform> ().position, firstPoint.GetComponent<Transform> ().rotation);
					Instantiate (pickup48, secondPoint.GetComponent<Transform> ().position, secondPoint.GetComponent<Transform> ().rotation);
				}

				if (twoOrThree == 3)
				{
					startPlace = Random.Range (0, 10);
					secondPlace = startPlace + Random.Range (4, 7);
					thirdPlace = secondPlace + Random.Range (4, 7);

					firstPoint = spawnerArray [startPlace];
					secondPoint = spawnerArray [secondPlace];
					thirdPoint = spawnerArray [thirdPlace];

					Instantiate (pickup48, firstPoint.GetComponent<Transform> ().position, firstPoint.GetComponent<Transform> ().rotation);
					Instantiate (pickup48, secondPoint.GetComponent<Transform> ().position, secondPoint.GetComponent<Transform> ().rotation);
					Instantiate (pickup48, thirdPoint.GetComponent<Transform> ().position, thirdPoint.GetComponent<Transform> ().rotation);
				}
			}

			if (roll > 95 && roll <= 100)
			{
				if (twoOrThree == 2)
				{
					startPlace = Random.Range (0, 10);
					secondPlace = Random.Range (14, 24);

					firstPoint = spawnerArray [startPlace];
					secondPoint = spawnerArray [secondPlace];

					Instantiate (pickup144, firstPoint.GetComponent<Transform> ().position, firstPoint.GetComponent<Transform> ().rotation);
					Instantiate (pickup144, secondPoint.GetComponent<Transform> ().position, secondPoint.GetComponent<Transform> ().rotation);
				}

				if (twoOrThree == 3)
				{
					startPlace = Random.Range (0, 10);
					secondPlace = startPlace + Random.Range (4, 7);
					thirdPlace = secondPlace + Random.Range (4, 7);

					firstPoint = spawnerArray [startPlace];
					secondPoint = spawnerArray [secondPlace];
					thirdPoint = spawnerArray [thirdPlace];

					Instantiate (pickup144, firstPoint.GetComponent<Transform> ().position, firstPoint.GetComponent<Transform> ().rotation);
					Instantiate (pickup144, secondPoint.GetComponent<Transform> ().position, secondPoint.GetComponent<Transform> ().rotation);
					Instantiate (pickup144, thirdPoint.GetComponent<Transform> ().position, thirdPoint.GetComponent<Transform> ().rotation);
				}
			}
		}
	}
}
