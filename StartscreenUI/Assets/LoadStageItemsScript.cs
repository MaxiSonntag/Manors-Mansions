using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadStageItemsScript : MonoBehaviour {

	public GameObject firstLevel;
	public GameObject secondLevel;
	public Sprite unlockedGame;
	public Sprite oneStarGame;
	public Sprite twoStarGame;
	public Sprite threeStarGame;
	public GameObject textLevel2;


	// Use this for initialization
	void Start () {
		textLevel2.GetComponent<Text> ().text = "";
		if (PlayerPrefs.GetInt ("unlockedLevels") == 2) {
			secondLevel.GetComponent<Image> ().sprite = unlockedGame;
			secondLevel.GetComponent<Button> ().interactable = true;
				textLevel2.GetComponent<Text>().text = "2";
		}
		if (PlayerPrefs.GetInt ("coins") <= 10 && PlayerPrefs.GetInt("coins") > 0) {
			firstLevel.GetComponent<Image> ().sprite = oneStarGame;
		} else if (PlayerPrefs.GetInt ("coins") <= 20 && PlayerPrefs.GetInt ("coins") > 10) {
			firstLevel.GetComponent<Image> ().sprite = twoStarGame;
		}else if(PlayerPrefs.GetInt ("coins") > 20){
			firstLevel.GetComponent<Image> ().sprite = threeStarGame;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
