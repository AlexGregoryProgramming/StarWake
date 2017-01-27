#pragma warning disable 0162 // Unreachable code detected

using UnityEngine;

public sealed class InputManager : MonoBehaviour {

    public static bool IsStartPressed {
        get {
            if (Platform.IsOSX) {
                return Input.GetButton("StartOSX");
            }

            return Input.GetButton("Start");
        }
    }

    public static bool IsSubmitPressed {
        get {
            if (Platform.IsOSX) {
                return Input.GetButton("SubmitOSX");
            }

            return Input.GetButton("Submit");
        }
    }

    public static bool IsCancelPressed {
        get {
            if (Platform.IsOSX) {
                return Input.GetButton("CancelOSX");
            }

            return Input.GetButton("Cancel");
        }
    }

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
