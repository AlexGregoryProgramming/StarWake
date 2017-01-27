using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ResultsScreenScript : MonoBehaviour
{
	public GameObject p1Block;
	public GameObject p2Block;
	public GameObject p3Block;
	public GameObject p4Block;
	public GameObject winnerBlock;

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

    struct PlayerResults {
        public int playerNumber;
        public GameObject block;
        public int wins;
        public Color color;
        public Text text;
    };

    PlayerResults[] _playerResults;

	// Use this for initialization
	void Start() {
        _playerResults = new PlayerResults[GameManager.PlayerCount];

        foreach (var player in GameManager._GAMEMANAGER.Players) {
            var playerResult = _playerResults[player.playerNumber - 1];

            playerResult.playerNumber = player.playerNumber;
            playerResult.wins = player.wins;

            switch (player.playerNumber) {
                case 1:
                    playerResult.block = p1Block;
                    playerResult.color = p1Color;
                    playerResult.text = p1Text;
                    break;

                case 2:
                    playerResult.block = p2Block;
                    playerResult.color = p2Color;
                    playerResult.text = p2Text;
                    break;

                case 3:
                    playerResult.block = p3Block;
                    playerResult.color = p3Color;
                    playerResult.text = p3Text;
                    break;

                case 4:
                    playerResult.block = p4Block;
                    playerResult.color = p4Color;
                    playerResult.text = p4Text;
                    break;
            }

            playerResult.block.GetComponent<VectorGridForce>().m_Color = GameManager.PlayerColorToColor(player.color);
        }

		StartCoroutine(results());
	}

	public IEnumerator results()
	{
        foreach (var playerResult in _playerResults) {
            yield return new WaitForSeconds(1);

            playerResult.text.gameObject.SetActive(true);
            playerResult.text.text = playerResult.wins.ToString();
            playerResult.block.GetComponent<VectorGridForce>().m_VectorGrid.AddGridForce(playerResult.block.transform.position, 0.8f * playerResult.wins / GameManager._GAMEMANAGER.winsNeeded, 0.8f * playerResult.wins / GameManager._GAMEMANAGER.winsNeeded, playerResult.color, true);
        }

		yield return new WaitForSeconds(1);

        foreach (var playerResult in _playerResults) {
            if (playerResult.wins == GameManager._GAMEMANAGER.winsNeeded) {
                winnerBlock.GetComponent<VectorGridForce>().m_Color = playerResult.color;
                winnerText.color = playerResult.color;
                winnerText.text = string.Format("Player {0} Wins", playerResult.playerNumber);
                winnerBlock.GetComponent<VectorGridForce>().m_VectorGrid.AddGridForce(winnerBlock.GetComponent<Transform>().position, 1, 1, winnerBlock.GetComponent<VectorGridForce>().m_Color, true);
                break;
            }
        }

		yield return new WaitForSeconds(1);

		continueText.gameObject.SetActive(true);
		isDone = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
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
