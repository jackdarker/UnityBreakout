using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float m_InitSpeed = 600f;
    private Rigidbody rb;
    private bool m_HasBall=true;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        m_HasBall = true;

    }
	
	// Update is called once per frame
	void Update () {
		if(m_HasBall && Input.GetButtonDown("Fire1")) {
            transform.parent = null;
            m_HasBall = false;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(m_InitSpeed, m_InitSpeed, 0));
        }
	}
}
