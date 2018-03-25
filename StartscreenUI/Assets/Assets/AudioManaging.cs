using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManaging : MonoBehaviour {

	public AudioSource audioSource;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		audioSource.volume = PlayerPrefs.GetFloat ("volume");
	}
	
	// Update is called once per frame
	void Update () {
		int currentScene = SceneManager.GetActiveScene ().buildIndex;
		if (currentScene < 6 || currentScene > 9){
			Destroy (gameObject);
		}
	}
}
