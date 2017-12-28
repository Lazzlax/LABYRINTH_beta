using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skripJembatanOncor : MonoBehaviour {
	public Rigidbody fisika;
	int i;
	[HideInInspector]public bool overideEverything;//goes backward
	[HideInInspector]public bool overideMarching;//goes forward
	public skripOncorManager oncorMaster;
	[HideInInspector]public bool eksekusi;
	[HideInInspector]public bool canCollide;
	[HideInInspector]public bool nowCollide;
	[HideInInspector]public bool thisOncorForward;
	public Vector3 posisiTujuan;
	public Vector3 posisiAwal;
	public Vector3 posisiRigid;
	public float speed;
	bool ofcol;
	// Use this for initialization
	void Start () {
		posisiAwal = transform.position;
		posisiTujuan=transform.position;
	}
	void FixedUpdate(){
		if(eksekusi){
			updatingPosisi();	
		}
		overrun();
		posisiRigid = fisika.transform.position;
	}
	void overrun(){
		//dont check just go on until hit something
		if(overideEverything){
			if(!ofcol){
				canCollide=false;
				ofcol=true;
			}
				overideMarching=false;
				fisika.AddForce(-fisika.transform.forward*speed*Time.deltaTime);
		}
		if(overideMarching){
			if(!ofcol){
				canCollide=false;
				ofcol=true;
			}
			overideEverything=false;
			fisika.AddForce(fisika.transform.forward*speed*Time.deltaTime);
		}
		}
	void updatingPosisi(){
		if(!overideEverything){
			if(thisOncorForward){
				fisika.AddForce(fisika.transform.forward*speed*Time.deltaTime);
			}
			if(!thisOncorForward){
				fisika.AddForce(-fisika.transform.forward*speed*Time.deltaTime);
			}
		}


		}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("jembatanStop")){
			Debug.Log("Interaksi");
			if(canCollide){
				fisika.velocity = Vector3.zero;
				nowCollide=true;
			}
			else{
				fisika.velocity = fisika.velocity;
			}
		}
if(overideEverything){
	 if (col.gameObject.CompareTag("Everythingstop")){
				Debug.Log("Abort progress");
				canCollide=true;
				oncorMaster.salah=false;
				oncorMaster.sekarangke =0;
				oncorMaster.start=false;
				while(i<oncorMaster.oncorObj.Length){
					oncorMaster.oncorObj[i].oncorNyala =false;
					oncorMaster.urutanPilihOncor[i]=0;
					i++;
				}
				ofcol=false;
				overideEverything=false;	
		}
	}
//
		if(overideMarching){
			if (col.gameObject.CompareTag("Everythingmarching")){
				Debug.Log("Continue progress");
				canCollide=true;
				oncorMaster.salah=false;
				oncorMaster.sekarangke =0;
				oncorMaster.start=false;
				/*while(i<oncorMaster.oncorObj.Length){
					oncorMaster.oncorObj[i].oncorNyala =false;
					oncorMaster.urutanPilihOncor[i]=0;
					i++;
				}*/
				ofcol=false;
				overideMarching=false;	
			}
		}
	}
}