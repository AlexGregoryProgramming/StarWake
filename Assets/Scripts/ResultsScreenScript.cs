using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultsScreenScript : MonoBehaviour
{
	public GameObject p1Block;
	public GameObject p2Block;
	public GameObject p3Block;
	public GameObject p4Block;
	public GameObject winnerBlock;

	public int p1Wins;
	public int p2Wins;
	public int p3Wins;
	public int p4Wins;

	public Color p1Color;
	public Color p2Color;
	public Color p3Color;
	public Color p4Color;

	public Text p1Text;
	public Text p2Text;
	public Text p3Text;
	public Text p4Text;
	public Text winnerText;
	public Text continueText;
	public bool isDone;
	// Use this for initialization
	void Start ()
	{
		p1Wins = GameManager._GAMEMANAGER.p1Wins;
		p2Wins = GameManager._GAMEMANAGER.p2Wins;
		p3Wins = GameManager._GAMEMANAGER.p3Wins;
		p4Wins = GameManager._GAMEMANAGER.p4Wins;

		if (GameManager._GAMEMANAGER.GetPlayerColor (1) == GameManager.PlayerColor.Red)
		{
			p1Block.GetComponent<VectorGridForce> ().m_Color = Color.red;
		}

		if (GameManager._GAMEMANAGER.GetPlayerColor (1) == GameManager.PlayerColor.Blue)
		{
			p1Block.GetComponent<VectorGridForce> ().m_Color = Color.blue;
		}

		if (GameManager._GAMEMANAGER.GetPlayerColor (1) == GameManager.PlayerColor.Green)
		{
			p1Block.GetComponent<VectorGridForce> ().m_Color = Color.green;
		}

		if (GameManager._GAMEMANAGER.GetPlayerColor (1) == GameManager.PlayerColor.Yellow)
		{
			p1Block.GetComponent<VectorGridForce> ().m_Color = Color.yellow;
		}




		if (GameManager._GAMEMANAGER.GetPlayerColor (2) == GameManager.PlayerColor.Red)
		{
			p2Block.GetComponent<VectorGridForce> ().m_Color = Color.red;
		}

		if (GameManager._GAMEMANAGER.GetPlayerColor (2) == GameManager.PlayerColor.Blue)
		{
			p2Block.GetComponent<VectorGridForce> ().m_Color = Color.blue;
		}

		if (GameManager._GAMEMANAGER.GetPlayerColor (2) == GameManager.PlayerColor.Green)
		{
			p2Block.GetComponent<VectorGridForce> ().m_Color = Color.green;
		}

		if (GameManager._GAMEMANAGER.GetPlayerColor (2) == GameManager.PlayerColor.Yellow)
		{
			p2Block.GetComponent<VectorGridForce> ().m_Color = Color.yellow;
		}


		if (GameManager._GAMEMANAGER.GetPlayerColor (3) == GameManager.PlayerColor.Red)
		{
			p3Block.GetComponent<VectorGridForce> ().m_Color = Color.red;
		}

		if (GameManager._GAMEMANAGER.GetPlayerColor (3) == GameManager.PlayerColor.Blue)
		{
			p3Block.GetComponent<VectorGridForce> ().m_Color = Color.blue;
		}

		if (GameManager._GAMEMANAGER.GetPlayerColor (3) == GameManager.PlayerColor.Green)
		{
			p3Block.GetComponent<VectorGridForce> ().m_Color = Color.green;
		}

		if (GameManager._GAMEMANAGER.GetPlayerColor (3) == GameManager.PlayerColor.Yellow)
		{
			p3Block.GetComponent<VectorGridForce> ().m_Color = Color.yellow;
		}


		if (GameManager._GAMEMANAGER.GetPlayerColor (4) == GameManager.PlayerColor.Red)
		{
			p4Block.GetComponent<VectorGridForce> ().m_Color = Color.red;
		}

		if (GameManager._GAMEMANAGER.GetPlayerColor (4) == GameManager.PlayerColor.Blue)
		{
			p4Block.GetComponent<VectorGridForce> ().m_Color = Color.blue;
		}

		if (GameManager._GAMEMANAGER.GetPlayerColor (4) == GameManager.PlayerColor.Green)
		{
			p4Block.GetComponent<VectorGridForce> ().m_Color = Color.green;
		}

		if (GameManager._GAMEMANAGER.GetPlayerColor (4) == GameManager.PlayerColor.Yellow)
		{
			p4Block.GetComponent<VectorGridForce> ().m_Color = Color.yellow;
		}


		StartCoroutine (results ());

	}


	public IEnumerator results()
	{
		yield return new WaitForSeconds (1);
		p1Text.gameObject.SetActive (true);
		p1Text.text = p1Wins.ToString();
		p1Block.GetComponent<VectorGridForce> ().m_VectorGrid.AddGridForce (p1Block.GetComponent<Transform> ().position, 0.8f * p1Wins / GameManager._GAMEMANAGER.winsNeeded, 0.8f * p1Wins / GameManager._GAMEMANAGER.winsNeeded, Color.yellow , true);

		yield return new WaitForSeconds (1);
		p2Text.gameObject.SetActive (true);
		p2Text.text = p2Wins.ToString();
		p2Block.GetComponent<VectorGridForce> ().m_VectorGrid.AddGridForce (p2Block.GetComponent<Transform> ().position, 0.8f * p2Wins / GameManager._GAMEMANAGER.winsNeeded , 0.8f * p2Wins / GameManager._GAMEMANAGER.winsNeeded, Color.red , true);

		yield return new WaitForSeconds (1);
		p3Text.gameObject.SetActive (true);
		p3Text.text = p3Wins.ToString();
		p3Block.GetComponent<VectorGridForce> ().m_VectorGrid.AddGridForce (p3Block.GetComponent<Transform> ().position, 0.8f * p3Wins / GameManager._GAMEMANAGER.winsNeeded, 0.8f * p3Wins / GameManager._GAMEMANAGER.winsNeeded, Color.blue , true);

		yield return new WaitForSeconds (1);
		p4Text.gameObject.SetActive (true);
		p4Text.text = p4Wins.ToString();
		p4Block.GetComponent<VectorGridForce> ().m_VectorGrid.AddGridForce (p4Block.GetComponent<Transform> ().position, 0.8f * p4Wins / GameManager._GAMEMANAGER.winsNeeded, 0.8f * p4Wins / GameManager._GAMEMANAGER.winsNeeded, Color.green , true);
		yield return new WaitForSeconds (1);
		if (p1Wins == GameManager._GAMEMANAGER.winsNeeded)
		{
			winnerBlock.GetComponent<VectorGridForce> ().m_Color = p1Color;
			winnerText.color = Color.yellow;
			winnerText.text = "Player 1 Wins";
			winnerBlock.GetComponent<VectorGridForce> ().m_VectorGrid.AddGridForce (winnerBlock.GetComponent<Transform> ().position, 1, 1, winnerBlock.GetComponent<VectorGridForce> ().m_Color, true);
		}

		if (p2Wins == GameManager._GAMEMANAGER.winsNeeded)
		{
			winnerBlock.GetComponent<VectorGridForce> ().m_Color = p2Color;
			winnerText.color = Color.red;
			winnerText.text = "Player 2 Wins";
			winnerBlock.GetComponent<VectorGridForce> ().m_VectorGrid.AddGridForce (winnerBlock.GetComponent<Transform> ().position, 1, 1, winnerBlock.GetComponent<VectorGridForce> ().m_Color, true);

		}

		if (p3Wins == GameManager._GAMEMANAGER.winsNeeded)
		{
			winnerBlock.GetComponent<VectorGridForce> ().m_Color = p3Color;
			winnerText.color = Color.blue;
			winnerText.text = "Player 3 Wins";
			winnerBlock.GetComponent<VectorGridForce> ().m_VectorGrid.AddGridForce (winnerBlock.GetComponent<Transform> ().position, 1, 1, winnerBlock.GetComponent<VectorGridForce> ().m_Color, true);
		}

		if (p4Wins == GameManager._GAMEMANAGER.winsNeeded)
		{
			winnerBlock.GetComponent<VectorGridForce> ().m_Color = p4Color;
			winnerText.color = Color.green;
			winnerText.text = "Player 4 Wins";
			winnerBlock.GetComponent<VectorGridForce> ().m_VectorGrid.AddGridForce (winnerBlock.GetComponent<Transform> ().position, 1, 1, winnerBlock.GetComponent<VectorGridForce> ().m_Color, true);
		}
		yield return new WaitForSeconds (1);

		continueText.gameObject.SetActive (true);
		isDone = true;



	}
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			p1Block.GetComponent<VectorGridForce> ().m_VectorGrid.AddGridForce (p1Block.GetComponent<Transform> ().position, 0.2f, 0.2f, p1Block.GetComponent<VectorGridForce> ().m_Color , true);
			p2Block.GetComponent<VectorGridForce> ().m_VectorGrid.AddGridForce (p2Block.GetComponent<Transform> ().position, 0.2f, 0.2f, p2Block.GetComponent<VectorGridForce> ().m_Color, true);
			p3Block.GetComponent<VectorGridForce> ().m_VectorGrid.AddGridForce (p3Block.GetComponent<Transform> ().position, 0.2f, 0.2f, p3Block.GetComponent<VectorGridForce> ().m_Color, true);
			p4Block.GetComponent<VectorGridForce> ().m_VectorGrid.AddGridForce (p4Block.GetComponent<Transform> ().position, 0.2f, 0.2f, p4Block.GetComponent<VectorGridForce> ().m_Color, true);
		}
		if (isDone == true)
		{
			if (InputManager.IsSubmitPressed) {
				UnityEngine.SceneManagement.SceneManager.LoadScene ("alexTestMainMenu");
			}
		}
	}
}
