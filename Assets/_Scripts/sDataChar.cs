using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Setup les differentes valeurs du char avec leurs valeurs */

public class sDataChar : MonoBehaviour {

	public float fspeed;
	public float frotatespeed;

	public Rigidbody rbreactor;

	// Use this for initialization
	void Start () {
		rbreactor = this.GetComponent<Rigidbody>();
		Debug.Log(rbreactor);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
