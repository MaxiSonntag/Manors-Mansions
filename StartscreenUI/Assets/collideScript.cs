using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class collideScript : MonoBehaviour {

	private string collisionInfo;
	public Text coins;
	public GameObject parent;
	public GameObject audioManager;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col) {
		
		audioManager.GetComponent<AudioSource> ().Play ();
		if (SceneManager.GetActiveScene ().buildIndex == 10) {
			int currentCoins = PlayerPrefs.GetInt ("coins");
			currentCoins += 1;	
			coins.text = currentCoins + "/25 Coins";
			PlayerPrefs.SetInt ("coins", currentCoins);
		} else if (SceneManager.GetActiveScene ().buildIndex == 11) {
			int currentCoins = PlayerPrefs.GetInt ("coins2");
			currentCoins += 1;
			coins.text = currentCoins + "/25 Coins";
			PlayerPrefs.SetInt ("coins2", currentCoins);
		}
		Destroy (parent);

	}

}
