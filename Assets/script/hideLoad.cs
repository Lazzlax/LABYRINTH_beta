using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideLoad : MonoBehaviour {
    public GameObject loadBtn;
    public skripPlayerLogic p;
	// Use this for initialization
	void Start () {
        p.load();
        if (p.stage >= 1)
        {
            loadBtn.SetActive(true);
        }
        else {
            loadBtn.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
