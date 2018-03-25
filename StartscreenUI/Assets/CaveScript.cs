using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void dimm() {
		Color tmp = GetComponent<SpriteRenderer> ().color;
		tmp.a = 0.35f;
		GetComponent<SpriteRenderer> ().color = tmp;
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.gameObject.tag != "Muenze") {
			dimm ();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag != "Muenze") {
			dimm ();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag != "Muenze") {
			Color tmp = GetComponent<SpriteRenderer> ().color;
			tmp.a = 1.0f;
			GetComponent<SpriteRenderer> ().color = tmp;
		}
	}
}
