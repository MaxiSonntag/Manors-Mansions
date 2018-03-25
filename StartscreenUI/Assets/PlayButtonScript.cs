using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour {

	static string prevLevel = "PrevLevel";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playGame() {
		SceneManager.UnloadSceneAsync (1);
		SceneManager.LoadScene (2);
		PlayerPrefs.SetInt (prevLevel, 1);
	}

	public void startBuy() {
		SceneManager.UnloadSceneAsync (1);
		SceneManager.LoadScene (3);
		PlayerPrefs.SetInt (prevLevel, 1);
	}

	public void backToMainScreen() {
		int sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.UnloadSceneAsync (sceneIndex);
		SceneManager.LoadScene (PlayerPrefs.GetInt(prevLevel));
		PlayerPrefs.SetInt (prevLevel, 1);
	}

	public void exit() {
		Application.Quit ();
	}

	public void changeToLevelChoice() {
		SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
		PlayerPrefs.SetInt (prevLevel, SceneManager.GetActiveScene().buildIndex);
		SceneManager.LoadScene(4);
	}

	public void startSettingsScene() {
		int currentLevel = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.UnloadSceneAsync (currentLevel);
		PlayerPrefs.SetInt (prevLevel, currentLevel);
		SceneManager.LoadScene (5);
	}

	public void startCutscene(){
		int currentScene = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.UnloadSceneAsync (currentScene);
		SceneManager.LoadScene (6);
	}

	public void startLevel2(){
		int currentScene = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.UnloadSceneAsync (currentScene);
		SceneManager.LoadScene (11);
	}
}
