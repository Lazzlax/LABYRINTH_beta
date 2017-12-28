using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skripHopTrigger : MonoBehaviour {
	public Animator animasi;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("Player")) {
			animasi.SetBool ("hop",true);
		}
	}
}
