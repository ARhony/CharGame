using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sRotationPilot : MonoBehaviour {

	//Transform
	Transform	t_Pilot;
	Transform	t_Engine;

	//GameObject
	GameObject	go_Engine;

	//Vectors
	Vector3		v3_RotationFromEngine;
	Vector3		v3_PositionFromEngine;

	// Use this for initialization
	void Start () {

		//Get the Engine GameObject
		go_Engine = GameObject.FindGameObjectWithTag("engine");

		//Initialize the transforms
		t_Pilot = this.transform;
		t_Engine = go_Engine.transform;

		//Initialize vectors
		Vector3 v3_Zero = new Vector3(0, 0, 0);
		v3_RotationFromEngine = v3_Zero;
		v3_PositionFromEngine = v3_Zero;
	}
	
	// Update is called once per frame
	void Update () {
		Rotation(); //Keeps the pilot behind the engine
		CheckPosition(); //Keeps the position of the pilot next to the engine
	}

	void Rotation(){
		//Rotate the pilot on how the engine rotate
		v3_RotationFromEngine = t_Engine.rotation.eulerAngles;
		t_Pilot.rotation = Quaternion.Euler(v3_RotationFromEngine);
	}

	void CheckPosition(){
		//Check the position from the pilot and set the position of the engine
		v3_PositionFromEngine = t_Engine.position;
		t_Pilot.position = v3_PositionFromEngine;
	}
}
