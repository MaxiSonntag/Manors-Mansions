using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrehScript : MonoBehaviour {

	public Text coins;
	private int coinAnzahl = 0;
	// Use this for initialization
	void Start () {

		IEnumerator coroutine = WaitTurn (0.03f);
		StartCoroutine (coroutine);
	}

	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator WaitTurn(float waitTime)
	{
		while (true)
		{
			yield return new WaitForSeconds(waitTime);
			transform.Rotate (new Vector3 (0, 0, 2));
		}
	}



	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			coinAnzahl += 1;
			coins.text = coinAnzahl + "/30 Coins";
		}
	}
}
