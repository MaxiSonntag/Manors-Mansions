using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameAfterCutscene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startGameAfterCutscene(){
		SceneManager.UnloadSceneAsync (SceneManager.GetActiveScene ().buildIndex);
		SceneManager.LoadScene (10);
	}
}
