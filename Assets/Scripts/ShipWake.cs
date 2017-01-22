using UnityEngine;

public class ShipWake : MonoBehaviour {

    public bool generateWake = true;

    public WakeCollider wakeColliderPrefab;

    private ShipColor shipColor;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() {
        shipColor = GetComponentInParent<ShipColor>();
        if (shipColor == null) {
            Debug.LogWarning("ShipWake should be attached to a hierarchy with a ShipColor component", this);
            enabled = false;
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        if (generateWake && (wakeColliderPrefab != null)) {
            WakeCollider wakeCollider = Instantiate<WakeCollider>(wakeColliderPrefab, transform.position, transform.rotation);
            if (wakeCollider != null) {
                int playerNumber = shipColor.playerNumber;
                wakeCollider.playerNumber = playerNumber;
                wakeCollider.playerColor = GameManager._GAMEMANAGER.GetPlayerColor(playerNumber);
            }
        }
    }
}
