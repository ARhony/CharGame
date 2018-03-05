using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class sMotionChar : MonoBehaviour {

	//Controller for the xbox api (mac)
	public XboxController	controller;

	//Floats
	public float			f_Speed;
	public float			f_SpeedForwardLimit;
	public float			f_SpeedBackwardLimit;

	//Transform for the char
	private Transform		tr_CharController;

	// Use this for initialization
	void Start () {
		//Get the char transform
		tr_CharController = this.transform;
		
		//Float
		f_Speed = 0.0f;
		f_SpeedForwardLimit = 40.0f;
		f_SpeedBackwardLimit = -25.0f;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		//Apply the motion
		if (checkInputForward()){f_Speed = f_Speed < f_SpeedForwardLimit ? f_Speed + 4.0f : f_Speed;}
		if (checkInputBackward()){f_Speed = f_Speed > f_SpeedBackwardLimit ? f_Speed - 2.0f : f_Speed;}
		if (!checkInputForward() && !checkInputBackward())
		{
			if (f_Speed > 0.1f) f_Speed = f_Speed - 1.0f;
			else if (f_Speed < -0.1) f_Speed = f_Speed + 1.0f;
			else f_Speed = 0.0f;
		}

		//Apply motion to the engine
		tr_CharController.position += tr_CharController.forward * f_Speed * Time.deltaTime;
	}

	//Check (Forward) if there is an input from the Right Trigger
	//If yes return TRUE, if no return FALSE
	bool checkInputForward(){
		if (XCI.GetAxis(XboxAxis.RightTrigger, controller) > 0.9f){return (true);}
		else {return (false);}
	}

	//Check (Backward) if there is an input from the Left Trigger
	//If yes return TRUE, if no return FALSE
	bool checkInputBackward(){
		if (XCI.GetAxis(XboxAxis.LeftTrigger, controller) < 0.1f){return (true);}
		else {return (false);}
	}
}