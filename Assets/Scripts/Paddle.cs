using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public float m_Speed=1.0f;
    private Vector3 m_PlayerPos = new Vector3(0, -9.5f, 0);
		
	// Update is called once per frame
	void Update () {
        float xPos = transform.position.x + Input.GetAxis("Horizontal")*m_Speed;
        m_PlayerPos = new Vector3(Mathf.Clamp(xPos, -8, 8), -9.5f, 0f);
        transform.position = m_PlayerPos;
	}
}
