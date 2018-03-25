using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerInterface : MonoBehaviour {

	public AudioSource interfaceSound;
	// Use this for initialization
	void Start () {
		interfaceSound.volume = PlayerPrefs.GetFloat ("volume");
		DontDestroyOnLoad (gameObject);
		if (PlayerPrefs.GetInt ("InterfaceMusic") == 1) {
			interfaceSound.Play ();
			PlayerPrefs.SetInt ("InterfaceMusic", 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		int currentScene = SceneManager.GetActiveScene ().buildIndex;
		if (currentScene < 1 || currentScene > 5){
			Destroy (gameObject);
		}
		interfaceSound.volume = PlayerPrefs.GetFloat ("volume");
	}
}
