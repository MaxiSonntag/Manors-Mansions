using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {

	public GameObject pauseScreen;
	public GameObject pauseButton;
	public GameObject continueButton;
	public GameObject restartButton;
	public GameObject homeButton; 
	// Use this for initialization
	void Start () {
		pauseScreen.GetComponent<SpriteRenderer>().enabled = false;
		continueButton.gameObject.SetActive (false);
		restartButton.gameObject.SetActive (false);
		homeButton.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void onClickPauseButton(){
		Time.timeScale = 0;
		pauseScreen.GetComponent<SpriteRenderer> ().enabled = true;
		pauseButton.gameObject.SetActive (false);
		continueButton.gameObject.SetActive (true);
		restartButton.gameObject.SetActive (true);
		homeButton.gameObject.SetActive (true);

	}

}
