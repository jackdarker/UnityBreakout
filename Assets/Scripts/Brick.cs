using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public GameObject BrickParticle;
    // Use this for initialization
    private void OnCollisionEnter(Collision collision) {
        Instantiate(BrickParticle, transform.position, Quaternion.identity);
        GM.instance.DestroyBrick();
        Destroy(gameObject);
    }
}
