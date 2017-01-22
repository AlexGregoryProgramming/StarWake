using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Wall : MonoBehaviour {
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() {
        GetComponent<BoxCollider>().isTrigger = true;
    }
}
