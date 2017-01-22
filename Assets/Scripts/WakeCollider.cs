using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class WakeCollider : MonoBehaviour {

    public float destroyAfterSeconds = 1.0f;

    public GameManager.PlayerColor playerColor = GameManager.PlayerColor.Dead;

    internal int playerNumber;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() {
        Destroy(gameObject, destroyAfterSeconds);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (playerColor == GameManager.PlayerColor.Dead) {
            // The color hasn't been set, so not a valid collision.
            return;
        }

        ShipColor shipColor = other.gameObject.GetComponent<ShipColor>();
        if (shipColor != null) {
            GameManager.PlayerColor shipPlayerColor = GameManager._GAMEMANAGER.GetPlayerColor(shipColor.playerNumber);
            if (shipPlayerColor != playerColor) {
                GameManager._GAMEMANAGER.KillPlayer(other.gameObject);
                Debug.Log(string.Format("Player {0} {1} wake killed player {2} {3}", playerNumber, playerColor, shipColor.playerNumber, shipPlayerColor));
            }
        }
    }
}
