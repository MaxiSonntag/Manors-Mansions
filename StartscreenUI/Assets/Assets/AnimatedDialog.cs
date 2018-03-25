using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AnimatedDialog : MonoBehaviour {

	public Text textObject;
	public string[] strings;

	float speed = 0.05f;
	int characterIndex= 0;
	int stringIndex = 0;

	// Use this for initialization
	void Start () {
		//StartCoroutine (animate ()

	}

	IEnumerator animate(){

		while (true) {
			yield return new WaitForSeconds(speed);
			textObject.text = strings[stringIndex].Substring (0, characterIndex);
			if (characterIndex < strings[stringIndex].Length) {
				characterIndex++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void startScript(){
		print ("startIndex:" + stringIndex);
		StartCoroutine (animate ());
		print ("after coroutine");
	}

	void clearText(){
		StopCoroutine (animate ());
		stringIndex++;
		textObject.text = "";
		characterIndex = 0;
	}
}
