using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagingGame : MonoBehaviour {

	public AudioSource jumpSound;
	public AudioSource mergeSound;
	public AudioSource popSound;
	public AudioSource song;

	// Use this for initialization
	void Start () {
		jumpSound.volume = PlayerPrefs.GetFloat ("volume");
		mergeSound.volume = PlayerPrefs.GetFloat ("volume");
		popSound.volume = PlayerPrefs.GetFloat ("volume");
		song.volume = PlayerPrefs.GetFloat ("volume") * 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
