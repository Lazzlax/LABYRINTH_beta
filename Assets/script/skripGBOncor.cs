using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skripGBOncor : MonoBehaviour {
	[Range(1,4)]public int identitas;
	public bool oncorMaju;
	public bool oncorAktif;
	public bool oncorNyala;
	public skripOncorManager oncorMaster;
	public skripJembatanOncor[] jembatanInfo;
	public int jembatanYang;
	public int aray;
	public string tagAction;//interaksi dengan
	public skripJoyInput playerinput;
	// Use this for initialization
	void Start () {

	}
	void Update(){
		aray=oncorMaster.sekarangke;
		if(oncorNyala){
			oncorAktif=false;
		}
			if(oncorAktif){
				jembatanInfo[jembatanYang].thisOncorForward = oncorMaju;
				//
				if(oncorMaju){
					jembatanInfo[jembatanYang].canCollide = false;
					jembatanInfo[jembatanYang].eksekusi = true;
					jembatanInfo[jembatanYang].canCollide = true;
					playerinput.banInput = true;
					oncorMaster.urutanPilihOncor[aray]=identitas;
					if(jembatanInfo[jembatanYang].nowCollide){//menabrak
						jembatanInfo[jembatanYang].eksekusi =false;
						playerinput.banInput = false;
						jembatanInfo[jembatanYang].nowCollide =false;
						oncorMaster.sekarangke +=1;
						oncorNyala=true;
						oncorAktif=false;
					}
				}
				else if(!oncorMaju){
					jembatanInfo[jembatanYang].canCollide = false;
					jembatanInfo[jembatanYang].eksekusi = true;
					jembatanInfo[jembatanYang].canCollide = true;
					playerinput.banInput =true;
					oncorMaster.urutanPilihOncor[aray]=identitas;
					if(jembatanInfo[jembatanYang].nowCollide){
						playerinput.banInput =false;
						jembatanInfo[jembatanYang].eksekusi =false;
						jembatanInfo[jembatanYang].nowCollide =false;
						oncorMaster.sekarangke +=1;
						oncorNyala=true;
						oncorAktif=false;
					}
				}
				//
				
			}
		}
}
	
		

	
