using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class utilitasSkrip : MonoBehaviour {
    skripPlayerLogic player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<skripPlayerLogic>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void exitMainMenu() {
        player.stage = 0;
        player.lives = 3;
        player.save();
        SceneManager.LoadScene(0);
    }
}
