using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashscreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("InterfaceMusic", 1);
		PlayerPrefs.SetFloat ("volume", 1);
		PlayerPrefs.SetInt ("unlockedLevels", 1);
		PlayerPrefs.SetInt ("coins", 0);
		PlayerPrefs.SetInt ("coins2", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void continueToStartscreen(){
		SceneManager.UnloadSceneAsync (0);
		SceneManager.LoadScene (1);
		AndroidJavaClass aClass = new AndroidJavaClass ("de.hof.basti.UnityPlayerActivity");
		aClass.CallStatic ("receiveMessage", "startMainOverlay");
	}
}
