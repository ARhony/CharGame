using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class sRotationEngine : MonoBehaviour {

	//Controller for the xbox api (mac)
	public XboxController	controller;
	//Floats
	public float 		f_axisX;
	public float 		f_axisY;
	private float		f_direction;
	private float		f_InputDeadZone;

	//Transforms
	private Transform 	t_DummyDirectionEngine;
	private Transform	t_Engine;
	private	Transform	t_RotationEngineDummy;

	//Vector3
	private Vector3		v3_NewRotation;
	private Vector3		v3_DirectionDummy;

	//GameOject
	public GameObject	go_RotationEngineDummy;
	public GameObject	go_DummyDirectionEngine;
	public GameObject	go_Engine;

	//Quaternion
	public Quaternion	q_rot;

	// Use this for initialization
	void Start () {

		//Floats
		f_axisX = 0.0f;
		f_axisY = 0.0f;
		f_direction = 0.0f;
		f_InputDeadZone = 0.1f;

		//GameOjects
		go_RotationEngineDummy = GameObject.FindGameObjectWithTag("RotationEngineDummy");
		go_DummyDirectionEngine = GameObject.FindGameObjectWithTag("DirectionEngineDummy");
		go_Engine = GameObject.FindGameObjectWithTag("engine");

		//Transform
		t_Engine = go_Engine.transform;
		t_RotationEngineDummy = go_RotationEngineDummy.transform;
		t_DummyDirectionEngine = go_DummyDirectionEngine.transform;

		//Vector3
		v3_DirectionDummy = new Vector3(0.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if ((XCI.GetAxis(XboxAxis.LeftStickX, controller) > 0.9 || XCI.GetAxis(XboxAxis.LeftStickX, controller) < -0.9)
			|| (XCI.GetAxis(XboxAxis.LeftStickY, controller) > 0.9 || XCI.GetAxis(XboxAxis.LeftStickY, controller) < -0.9)){
			f_axisX = XCI.GetAxis(XboxAxis.LeftStickX, controller);
			f_axisY = XCI.GetAxis(XboxAxis.LeftStickY, controller);
		}
		f_direction = Mathf.Atan2(f_axisX, f_axisY * (-1));

		t_RotationEngineDummy.rotation = Quaternion.Euler(0.0f, f_direction * Mathf.Rad2Deg, 0.0f);

		v3_DirectionDummy = t_DummyDirectionEngine.position - t_RotationEngineDummy.position;

		q_rot = Quaternion.LookRotation(v3_DirectionDummy);

		t_Engine.rotation = Quaternion.Slerp(t_Engine.rotation, q_rot, 2f * Time.deltaTime);
	}

	void Update(){
		t_Engine.localRotation = Quaternion.Slerp(t_Engine.localRotation, q_rot, 6.0f * Time.deltaTime);
	}
}
