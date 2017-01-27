#pragma warning disable 0162 // Unreachable code detected

using UnityEngine;

public sealed class InputManager : MonoBehaviour {

    /// <summary>
    /// Returns true while the Start button is held down on any connected controller.
    /// </summary>
    public static bool IsStartPressed {
        get {
            if (Platform.IsOSX) {
                return Input.GetButtonDown("StartOSX");
            }

            return Input.GetButtonDown("Start");
        }
    }

    /// <summary>
    /// Returns true while the Submit button (usually A or the Return key) is held down on any connected controller.
    /// </summary>
    public static bool IsSubmitPressed {
        get {
            if (Platform.IsOSX) {
                return Input.GetButtonDown("SubmitOSX");
            }

            return Input.GetButtonDown("Submit");
        }
    }

    /// <summary>
    /// Returns true while the Cancel button (usually B or the Escape key) is held down on any connected controller.
    /// </summary>
    /// <returns></returns>
    public static bool IsCancelPressed {
        get {
            if (Platform.IsOSX) {
                return Input.GetButtonDown("CancelOSX");
            }

            return Input.GetButtonDown("Cancel");
        }
    }

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
