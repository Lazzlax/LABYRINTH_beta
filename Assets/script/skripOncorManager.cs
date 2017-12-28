using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skripOncorManager : MonoBehaviour {
	public int sekarangke=0;
	public int[] urutanBenarOncor;//posisi benar. diinput saat membuat puzzle. diinput oleh gameDesigner
	public int[] urutanPilihOncor;//posisi yang dipilih player. diinput player saat gameplay
	public skripGBOncor[] oncorObj;
	public skripJembatanOncor[] JembatanGB;//gameobject oncor
	public bool salah;
	public bool start;

	/*
	 cara pengoperasian . author SoftLeafGame
	 1. buat game object sebagai jembatan yang berisi rigidbody(freeze rotation x,y,z),box collider,skripJembatan Oncor
	 2. buat children pada gameobject diatas sebagai bentuk aslinya dari jembatan.
	 3. buat satu children lagi sebagai collider. masukkan layer jembatancollision.
	 4. buat gameobject lain jadikan sebagai collider trigger jika jembatan menabraknya.
	 5. pastikan physic collider sudah diatur hanya layer jembatan collision yang bisa saling berinteraksi.
	  */
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cekBenar();
	}

	void cekBenar(){
		
		if(sekarangke==4){
			int i=0;
			while(i<4){
				if(urutanPilihOncor[i]!=urutanBenarOncor[i]){
					salah=true;
				}
				i++;
			}

			if(salah){
				if(!start){
				 	i=0;
					while(i<JembatanGB.Length){
						JembatanGB[i].GetComponent<skripJembatanOncor>().overideEverything=true;
						i++;
					}
				start=true;
				}
			}
			else if(!salah){
				if(!start){
					i=0;
					while(i<JembatanGB.Length){
						JembatanGB[i].GetComponent<skripJembatanOncor>().overideMarching=true;
						i++;
					}
					start=true;
				}
			}
		}
	}
}
