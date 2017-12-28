using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//BBerinteraksi ketika dekat oncor
public class skripPlayerN : MonoBehaviour {
	public string oncorTag;
	skripJoyInput inputInsp;
	public bool inspeksi;
	// Use this for initialization
	void Start () {
		inputInsp = GetComponent<skripJoyInput>();
	}
	
	// Update is called once per frame
	void Update () {
		inspeksi = inputInsp.inspect;
	}

	void OnTriggerEnter(Collider col){

	}

	void OnTriggerStay(Collider col){
		if(inspeksi){
			Debug.Log("Inspseksi");
			if(col.gameObject.CompareTag(oncorTag)){
				Debug.Log("Omcor Tag");
				skripGBOncor akses = col.gameObject.GetComponent<skripGBOncor>();
				if(akses !=null){
					Debug.Log("Not nnull");
					akses.oncorAktif = true;
				}
			}	
		}
	}
}
