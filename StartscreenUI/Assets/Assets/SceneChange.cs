using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadSecondScene(){

		SceneManager.LoadScene (7);
	}

	void LoadThirdScene(){

		SceneManager.LoadScene (8);
	}

	void LoadFourthScene(){
		SceneManager.LoadScene (9);
	}
}

