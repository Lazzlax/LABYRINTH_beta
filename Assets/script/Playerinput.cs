using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerinput : MonoBehaviour {
	Animator Animasi;
	public bool isIdle;
	public float V;
	public float H;

	// Use this for initialization
	void Start () {
		Animasi = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
//		isIdle = Mathf.Abs (V) == 0f && Mathf.Abs (H) == 0f;
//		idleFix ();
		V = Input.GetAxis ("Vertical");
		H = Input.GetAxis ("Horizontal");
		ControlAnimasi (H, V);
	}
	void idleFix(){
		if (isIdle) {
			Animasi.applyRootMotion = false;
		} 
		if(!isIdle)
		{
			Animasi.applyRootMotion = true;
		}
	}
	void ControlAnimasi(float H,float V){
		Animasi.SetFloat ("H",H);
		Animasi.SetFloat ("V", V);

	}
	void LateUpdate(){
		Animasi.SetLayerWeight (1, 1f);
	}
}
