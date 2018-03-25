using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSwitch : MonoBehaviour {

	public Sprite[] sprites;
	Transform[] ts;
	GameObject imageView;
	Image image;
	int index = 0;
	GameObject prev;
	Button prevButton;
	Button next;

	// Use this for initialization
	void Start () {
		ts = transform.GetComponentsInChildren<Transform> ();
	
		foreach(Transform t in ts){
			if (t.gameObject.name == "LevelHaus") {
				imageView = t.gameObject;
			}
			if (t.gameObject.name == "ButtonPrev") {
				prev = t.gameObject;
				prevButton = prev.GetComponent<Button> ();
			}
			if (t.gameObject.name == "ButtonNext") {
				next = t.gameObject.GetComponent<Button>();
			}
		}


		//imageView.GetComponent<Image> ();
		image = imageView.GetComponent<Image> ();
		prevButton.interactable = false;
		image.sprite = sprites [index];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void nextSprite(){
		if (index < sprites.Length) {
			index++;
		}
		if (index == sprites.Length - 1) {
			next.interactable = false;
		}

		image.sprite = sprites [index];
		prevButton.interactable = true;
	}

	public void previousSprite(){
		if (index > 0) {
			index--;
		}
			
		if (index == 0) {
			prevButton.interactable = false;
		}
		image.sprite = sprites [index];
		next.interactable = true;
	}
}
