using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalGridForce : VectorGridForce {

	// Update is called once per frame
	void Update () {
        m_VectorGrid.AddGridForce(this.transform.position, transform.up * m_ForceScale, m_Radius, m_Color, m_HasColor);
	}
}
