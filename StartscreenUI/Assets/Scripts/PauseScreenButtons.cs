using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenButtons : MonoBehaviour {

	public GameObject pauseScreen;
	public GameObject pauseButton;
	public GameObject continueButton;
	public GameObject restartButton;
	public GameObject homeButton;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("playerCount",4);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void onClickContinue(){
		pauseScreen.GetComponent<SpriteRenderer> ().enabled = false;
		pauseButton.gameObject.SetActive (true);
		continueButton.gameObject.SetActive (false);
		restartButton.gameObject.SetActive (false);
		homeButton.gameObject.SetActive (false);
		Time.timeScale = 1;
	}

	public void onClickRestart(){
		int currentScene = SceneManager.GetActiveScene().buildIndex;
		pauseButton.gameObject.SetActive (true);
		SceneManager.LoadScene (currentScene);
		Time.timeScale = 1;
		PlayerPrefs.SetInt ("playerCount",4);
		PlayerPrefs.SetInt ("coins", 0);
		PlayerPrefs.SetInt ("coins2", 0);
	}

	public void onClickHome(){
		int currentScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.UnloadSceneAsync(currentScene);
		SceneManager.LoadScene (1);
		Time.timeScale = 1;
		PlayerPrefs.SetInt ("playerCount",4);
		PlayerPrefs.SetInt ("coins", 0);
		PlayerPrefs.SetInt ("coins2", 0);
	}
}
