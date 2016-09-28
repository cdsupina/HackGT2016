using UnityEngine;
using System.Collections;

public class Forces : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddForce(Vector3.left * 1000f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
