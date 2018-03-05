using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
public class PlayerSpells : MonoBehaviour {

    public XboxController	controller;
    public GameObject Vehicule;
    public GameObject Bullet;

    public int playerID;
    
    public float Cooldown_shoot;

    public float cd_Shoot;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

        if(cd_Shoot > 0)
        {
            
            if ((cd_Shoot - Time.deltaTime)<0) cd_Shoot = 0;
            else cd_Shoot = cd_Shoot - Time.deltaTime;
        }
         
        Shoot();
	}

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1")/*XCI.GetButton(XboxButton.X, controller)*/ && cd_Shoot == 0)
        {
            GameObject clone;
            Vector3 BulletSpawn = new Vector3(0,0,0);
            BulletSpawn = Vehicule.transform.position;

            clone = Instantiate(Bullet, BulletSpawn, Vehicule.transform.rotation);
            
            cd_Shoot = Cooldown_shoot;
            Debug.Log(cd_Shoot);
        }

    }
}
