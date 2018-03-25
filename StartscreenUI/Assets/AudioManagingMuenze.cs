using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagingMuenze : MonoBehaviour {

	public AudioSource muenzeSound;
	// Use this for initialization
	void Start () {
		muenzeSound.volume = PlayerPrefs.GetFloat ("volume");
	}
	
	// Update is called once per frame
	void Update () {
	}
}
