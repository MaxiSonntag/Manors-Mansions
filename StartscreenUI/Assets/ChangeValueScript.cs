using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeValueScript : MonoBehaviour {

	private float volume = 1;
	public Slider slider;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetFloat ("volume", volume);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onValueChanged(){
		volume = slider.value;
		PlayerPrefs.SetFloat ("volume", volume);
	}
}
