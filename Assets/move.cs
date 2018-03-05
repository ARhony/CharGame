using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class move : MonoBehaviour {

	public float speed = 2f;
	CharacterController player;
	float moveFB;
	float moveLR;

	// Use this for initialization
	void Start () 
	{
		player = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		moveFB = XCI.GetAxis(XboxAxis.LeftStickX) * speed;
		moveLR = XCI.GetAxis (XboxAxis.LeftStickY) * speed;
		Vector3 movement = new Vector3 (moveLR, 0, moveFB);
		player.Move (movement * Time.deltaTime);
	}
}
