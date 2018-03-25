using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCutscene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		print ("called");
	}
	
	// Update is called once per frame
	void Update () {
		int currentScene = SceneManager.GetActiveScene ().buildIndex;
		if (currentScene == 10) {
			Destroy (gameObject);
		}
	}

	public void Skip(){
		int currentScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.UnloadSceneAsync(currentScene);
		SceneManager.LoadScene (10);
		Destroy (gameObject);
		//#######LOAD GAME#######
		// Code here
		//######

	}
}
