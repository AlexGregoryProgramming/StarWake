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

    public static bool IsP1GreenDown {
        get {
            if (Platform.IsOSX) {
                return Input.GetKeyDown(KeyCode.Joystick1Button16);
            }

            return Input.GetKeyDown(KeyCode.Joystick1Button0);
        }
    }

    public static bool IsP2GreenDown {
        get {
            if (Platform.IsOSX) {
                return Input.GetKeyDown(KeyCode.Joystick2Button16);
            }

            return Input.GetKeyDown(KeyCode.Joystick2Button0);
        }
    }

    public static bool IsP3GreenDown {
        get {
            if (Platform.IsOSX) {
                return Input.GetKeyDown(KeyCode.Joystick3Button16);
            }

            return Input.GetKeyDown(KeyCode.Joystick3Button0);
        }
    }

    public static bool IsP4GreenDown {
        get {
            if (Platform.IsOSX) {
                return Input.GetKeyDown(KeyCode.Joystick4Button16);
            }

            return Input.GetKeyDown(KeyCode.Joystick4Button0);
        }
    }

    public static bool IsP1RedDown {
        get {
            if (Platform.IsOSX) {
                return Input.GetKeyDown(KeyCode.Joystick1Button17);
            }

            return Input.GetKeyDown(KeyCode.Joystick1Button1);
        }
    }

    public static bool IsP2RedDown {
        get {
            if (Platform.IsOSX) {
                return Input.GetKeyDown(KeyCode.Joystick2Button17);
            }

            return Input.GetKeyDown(KeyCode.Joystick2Button1);
        }
    }

    public static bool IsP3RedDown {
        get {
            if (Platform.IsOSX) {
                return Input.GetKeyDown(KeyCode.Joystick3Button17);
            }

            return Input.GetKeyDown(KeyCode.Joystick3Button1);
        }
    }

    public static bool IsP4RedDown {
        get {
            if (Platform.IsOSX) {
                return Input.GetKeyDown(KeyCode.Joystick4Button17);
            }

            return Input.GetKeyDown(KeyCode.Joystick4Button1);
        }
    }

    public static bool IsP1BlueDown {
        get {
            if (Platform.IsOSX) {
                return Input.GetKeyDown(KeyCode.Joystick1Button18);
            }

            return Input.GetKeyDown(KeyCode.Joystick1Button2);
        }
    }

    public static bool IsP2BlueDown {
        get {
            if (Platform.IsOSX) {
                return Input.GetKeyDown(KeyCode.Joystick2Button18);
            }

            return Input.GetKeyDown(KeyCode.Joystick2Button2);
        }
    }

    public static bool IsP3BlueDown {
        get {
            if (Platform.IsOSX) {
                return Input.GetKeyDown(KeyCode.Joystick3Button18);
            }

            return Input.GetKeyDown(KeyCode.Joystick3Button2);
        }
    }

    public static bool IsP4BlueDown {
        get {
            if (Platform.IsOSX) {
                return Input.GetKeyDown(KeyCode.Joystick4Button18);
            }

            return Input.GetKeyDown(KeyCode.Joystick4Button2);
        }
    }

    public static bool IsP1YellowDown {
        get {
            if (Platform.IsOSX) {
                return Input.GetKeyDown(KeyCode.Joystick1Button19);
            }

            return Input.GetKeyDown(KeyCode.Joystick1Button3);
        }
    }

    public static bool IsP2YellowDown {
        get {
            if (Platform.IsOSX) {
                return Input.GetKeyDown(KeyCode.Joystick2Button19);
            }

            return Input.GetKeyDown(KeyCode.Joystick2Button3);
        }
    }

    public static bool IsP3YellowDown {
        get {
            if (Platform.IsOSX) {
                return Input.GetKeyDown(KeyCode.Joystick3Button19);
            }

            return Input.GetKeyDown(KeyCode.Joystick3Button3);
        }
    }

    public static bool IsP4YellowDown {
        get {
            if (Platform.IsOSX) {
                return Input.GetKeyDown(KeyCode.Joystick4Button19);
            }

            return Input.GetKeyDown(KeyCode.Joystick4Button3);
        }
    }

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
