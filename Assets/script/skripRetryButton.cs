using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class skripRetryButton : MonoBehaviour {
	public int indexScene;
	public string namaScene;
	public GameObject uiGameOver;
	public GameObject uiOnlyExit;
	// Use this for initialization
	void Start () {

	}	
	// Update is called once per frame
	void Update () {
		
	}
	public void ResetGame(){
		GameObject.FindGameObjectWithTag ("Player").GetComponent<skripPlayerLogic> ().lives -= 1;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<skripPlayerLogic> ().save ();

		SceneManager.LoadScene(namaScene);
	}
	public void ShowGameOver(){
		uiGameOver.SetActive(true);
	}
	public void ShowOnlyExit(){
		uiOnlyExit.SetActive(true);
	}

	public void ExitAPP(){
        //Application.Quit();
        GameObject.FindGameObjectWithTag("Player").GetComponent<skripPlayerLogic>().save();
        SceneManager.LoadScene(0);
    }
}
