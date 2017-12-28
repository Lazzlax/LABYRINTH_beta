using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skripLoadScene : MonoBehaviour {
	public string namaLevel;
	public GameObject nextlvcanvas;
	public string playerTag;
    bool isLoaded;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void gotoLevel(string levelName){
        SceneManager.LoadScene(levelName);
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag(playerTag)){
            if (!isLoaded) {
                col.gameObject.GetComponent<skripPlayerLogic>().stage += 1;
                col.gameObject.GetComponent<skripPlayerLogic>().save();
                isLoaded = true;
            }
            
			nextlvcanvas.SetActive(true);
			SceneManager.LoadScene(namaLevel);
		}
	}
}
