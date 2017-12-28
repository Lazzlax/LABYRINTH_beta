using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skriprottMotionMove : MonoBehaviour {
	public Animator animasi;
	public Transform cameraTransform;
	public float turnSmoothing;
	public float speed;
	public bool isMoving;
	public Rigidbody fisika;
	public Vector3 lastDirection;
	public Vector3 targetDirection;
	public bool isForward;
	public bool isBackward;
	public bool isRight;
	public bool isLeft;
	public string NameVAxis;//name of Animator's parameter
	public string NameHAxis;

	// Use this for initialization
	void Start () {
		animasi = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SFLandControl(float x,float y){
		isMoving = Mathf.Abs(x) > 0.1 || Mathf.Abs(y) > 0.1;
		Rotating(x,y);
		AnimasiOnHandler (x,y);
	}
	public void AnimasiOnHandler(float x,float y){
		animasi.SetFloat ("H",x);
		animasi.SetFloat ("V",y);
	}
	void controlVar(float x,float y){
		if (y>0.1f) {
			Debug.Log ("forward");
			isBackward = false;
			isForward = true;
		}
		if (y<-0.1f) {
			Debug.Log ("backward");
			isForward = false;
			isBackward = true;
		}
		if (x>0.1f) {
			Debug.Log ("Right");
			isLeft = false;
			isRight = true;
		}
		if (x<-0.1f) {
			Debug.Log ("Left");
			isRight = false;
			isLeft = true;
		}
	}

	Vector3 Rotating(float horizontal, float vertical)
	{
		//search for forward direction based on camera
		Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
		//normalize this vector
		forward = forward.normalized;

		Vector3 right = new Vector3(forward.z, 0f, -forward.x);

//		Vector3 targetDirection;//rotate here

		float finalTurnSmoothing;

		//targetDirection = forward * vertical + right * horizontal;
		targetDirection = forward;
			finalTurnSmoothing = turnSmoothing;

		if((isMoving && targetDirection != Vector3.zero))
		{
			targetDirection.y =0f;
			Quaternion targetRotation = Quaternion.LookRotation (targetDirection, Vector3.up);

			Quaternion newRotation = Quaternion.Slerp(fisika.rotation, targetRotation, finalTurnSmoothing * Time.deltaTime);
			fisika.MoveRotation (newRotation);
			lastDirection = targetDirection;
		}
		//idle - fly or grounded
		if(!(Mathf.Abs(horizontal) > 0.9 || Mathf.Abs(vertical) > 0.9))
		{
			Repositioning();
		}

		return targetDirection;
	}	

	private void Repositioning()
	{
		Vector3 repositioning = lastDirection;
		if(repositioning != Vector3.zero)
		{
			repositioning.y = 0;
			Quaternion targetRotation = Quaternion.LookRotation (repositioning, Vector3.up);
			Quaternion newRotation = Quaternion.Slerp(fisika.rotation, targetRotation, turnSmoothing * Time.deltaTime);
			fisika.MoveRotation (newRotation);
		}
	}
}
