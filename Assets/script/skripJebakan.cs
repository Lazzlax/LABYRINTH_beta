using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skripJebakan : MonoBehaviour {
	//gerakkan keatas
	public GameObject jebakanOBJ;
	public Vector3 arahJebakan;
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void initJebakan(){
		jebakanOBJ.GetComponent<Rigidbody>().AddForce(arahJebakan*speed*Time.deltaTime);
		GameObject.FindGameObjectWithTag("Player").GetComponent<skripPlayerLogic>().isDead=true;
	}

	void OnTriggerEnter(Collider col){
		if(col.CompareTag("Player")){
			initJebakan();
		}
	}
}
