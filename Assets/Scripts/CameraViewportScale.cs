using UnityEngine;

// From: http://answers.unity3d.com/questions/391324/stretching-a-gameobject-to-fit-viewport.html
public class CameraViewportScale : MonoBehaviour {

    public new Camera camera;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
    }

	// Use this for initialization
	void Start () {
        ScaleToCameraViewport();
	}

	// Update is called once per frame
	void Update () {

	}

    public void ScaleToCameraViewport() {
        if (camera == null) {
            camera = Camera.main;
        }

        // Zero camera rotation to prevent scaling issues.
        Vector3 savedCameraRotation = camera.transform.rotation.eulerAngles;
        camera.transform.rotation = Quaternion.Euler(Vector3.zero);

        float distance = Vector3.Distance(transform.position, camera.transform.position);
        Vector3 viewBottomLeft = camera.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
        Vector3 viewTopRight = camera.ViewportToWorldPoint(new Vector3(1f, 1f, distance));
        Vector3 scale = viewTopRight - viewBottomLeft;
        scale.z = transform.localScale.z;
        transform.localScale = scale;

        // Restore the camera's rotation.
        camera.transform.rotation = Quaternion.Euler(savedCameraRotation);
    }
}
