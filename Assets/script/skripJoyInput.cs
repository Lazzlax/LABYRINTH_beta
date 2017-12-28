using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class skripJoyInput : MonoBehaviour {
	public skriprottMotionMove SFAnimasi;
	public bool inspect;
	public bool banInput;
	public string interactButton;
	public float hAxisValue;
	public string hAxisButton;
	public float vAxisValue;
	public string vAxisButton;
	public string AnimatDieName;
	public string AnimatIdleName;
	public string AnimatHAxisName;
	public string AnimatVAxisName;

	// Use this for initialization
	void Start () {
		
	}
	void Update(){
		inspect = CrossPlatformInputManager.GetButton(interactButton);
		hAxisValue=CrossPlatformInputManager.GetAxis(hAxisButton);
		vAxisValue=CrossPlatformInputManager.GetAxis(vAxisButton);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!banInput){
			SFAnimasi.SFLandControl(hAxisValue,vAxisValue);
		}
	}
		
}
