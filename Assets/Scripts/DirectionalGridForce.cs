using UnityEngine;

public class DirectionalGridForce : VectorGridForce {

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() {
        if (m_VectorGrid == null) {
            Debug.LogWarning("DirectionalGridForce should have a VectorGrid instance", this);
            enabled = false;
        }
    }

	// Update is called once per frame
	void Update() {
        m_VectorGrid.AddGridForce(this.transform.position, transform.up * m_ForceScale, m_Radius, m_Color, m_HasColor);
	}
}
