using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class skripPlayerLogic : MonoBehaviour {
	public int lives;
	public int stage;
	public bool resetData;
    public bool isSaveData;
	public string lokasi;
	Animator animasi;//aniamtor dor animation
	[HideInInspector]public bool isDead;//apakah player already dead
	skripJoyInput playerInput;//get player input atatus
	bool isPlayerMoving;//apakah player bergerak?(input)
	int dead;//hash dead animator
	int idle;//hash idle animator
	int hAxis;//hash hAxis animator
	int vAXis;//hash vAxis animator
	public Text teks;
	// Use this for initialization
	void Start () {
		load ();
        
        if (teks != null) {
            playerInput = GetComponent<skripJoyInput>();//get input reference
            animasi = GetComponent<Animator>();//get animator reference
                                               //every hash made animator call's performance up
            dead = Animator.StringToHash(playerInput.AnimatDieName);//set dead hash
            hAxis = Animator.StringToHash(playerInput.AnimatHAxisName);//set h hash
            vAXis = Animator.StringToHash(playerInput.AnimatVAxisName);//set v hash
            idle = Animator.StringToHash(playerInput.AnimatIdleName);//set idle hash
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        if (teks != null)
        {

            Dead(isDead);//let player play dead animation
		AnimasiHandler(playerInput.hAxisValue,playerInput.vAxisValue);//handle between idle and not animation


		//reset save data
		if(resetData){
			reset ();
			resetData = false;
		}
            if (isSaveData) {
                save();
                isSaveData = false;
            }
        //print
            if (isDead)
            {
                teks.text = "lives " + lives;
            }
        }
		
	}

	void AnimasiHandler(float h,float v){
		isPlayerMoving=Mathf.Abs(h)>.1f||Mathf.Abs(v)>.1f;//chechk whether player is attempt to move
		animasi.SetBool(idle,!isPlayerMoving);//set idle or moving state
	}

	void Dead(bool dying){
		if (lives > 0) {
			if (dying)
				GameObject.FindGameObjectWithTag ("GameController").GetComponent<skripRetryButton> ().ShowGameOver ();
		} else {
			if (dying)
				GameObject.FindGameObjectWithTag ("GameController").GetComponent<skripRetryButton> ().ShowOnlyExit ();
		}
		animasi.SetBool(dead,dying);//set player animation to dead state
	}
		
	//system
	public void save()
	{
		int i = 0;
		BinaryFormatter bin = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath+lokasi);
		//call the data class and parse to local value
		runData dataS = new runData();
		//save here
		dataS.lives = lives;
		dataS.stage = stage;
		//convert to binary. filename,data
		bin.Serialize(file,dataS);
		file.Close();
		Debug.Log("save success");
	}

	public void load()
	{
		//check if file exists
		if(File.Exists(Application.persistentDataPath+lokasi)){
			BinaryFormatter bin = new BinaryFormatter();
			//access
			FileStream file = File.OpenRead(Application.persistentDataPath+lokasi);
			runData dataS = (runData)bin.Deserialize(file);//convert me this
			file.Close();
			//parsing parameter
			lives = dataS.lives;
			stage = dataS.stage;
			//EndOfStreamException of parameter
		}
		Debug.Log("load success");
	}



	//system
	public void reset()
	{
		int i = 0;
		BinaryFormatter bin = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath+lokasi);
		//call the data class and parse to local value
		runData dataS = new runData();
		//save here
		dataS.lives = 3;
		dataS.stage = 0;
		//convert to binary. filename,data
		bin.Serialize(file,dataS);
		file.Close();
       // stage = 0;
        save();
		Debug.Log("Reset success");
	}

    public void StartGame() {
        stage = 0;
        lives = 3;
        stage ++;
        save();
        SceneManager.LoadScene(1);
    }

    public void exitAPP() {
        Application.Quit();
    }

    public void LoadLevel() {
            SceneManager.LoadScene(stage+1);
    }
	//system
}


//data to be saved
[Serializable]
class runData{
	public int lives;
	public int stage;
}
