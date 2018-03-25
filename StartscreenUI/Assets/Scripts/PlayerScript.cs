using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

	Rigidbody2D player;
	public int speedSmall = 40;
	public int speedBig = 70;
	public GameObject gameoverScreen;
	public GameObject restartButton;
	public GameObject homeButton;
	public GameObject pauseButton;
	private bool grounded = false;
	private bool splited = false;
	private Rigidbody2D one;
	private Rigidbody2D two;
	private Rigidbody2D three;
	private Vector3 scale = new Vector3(0.2924f,0.2924f,0.2924f);
	public GameObject audioManager;
	public GameObject splitSymbol;
	public Sprite splitSprite;
	public Sprite unsplitSprite;
	public bool isMain = true;
	private bool onGameOver = false;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D> ();
		gameoverScreen.GetComponent<SpriteRenderer> ().enabled = false;
		restartButton.gameObject.SetActive (false);
		homeButton.gameObject.SetActive (false);
		PlayerPrefs.SetInt ("InterfaceMusic", 1);
		checkIfAlone ();
	}

	void checkIfAlone(){
		if(PlayerPrefs.GetInt("playerCount") == 1){
			player.GetComponent<SpriteRenderer> ().color = UnityEngine.Color.white;
		}
	}

	void mergeMitch(){
		if (PlayerPrefs.GetInt ("playerCount") > 1) {
			player.transform.localScale = scale * (0.25f * PlayerPrefs.GetInt ("playerCount"));
		}
		if (one != null) {
			one.gameObject.SetActive (false);
			Destroy (one.gameObject);
		}
		if (two != null) {
			two.gameObject.SetActive (false);
			Destroy (two.gameObject);
		}
		if (three != null) {
			three.gameObject.SetActive (false);
			Destroy (three.gameObject);
		}
		splited = false;
	}

	void highlightMitch(){
		if (this.GetComponent<PlayerScript> ().isMain && PlayerPrefs.GetInt ("playerCount") > 1) {
			player.GetComponent<SpriteRenderer> ().color = UnityEngine.Color.yellow;
		} else if (!this.GetComponent<PlayerScript> ().isMain) {
			player.GetComponent<SpriteRenderer> ().color = UnityEngine.Color.white;
		}
		if (!splited) {
			player.GetComponent<SpriteRenderer> ().color = UnityEngine.Color.white;
		}
		if (PlayerPrefs.GetInt ("playerCount") == 1) {
			player.GetComponent<SpriteRenderer> ().color = UnityEngine.Color.white;
		}
	}	
	
	// Update is called once per frame
	void Update () {

		checkIfAlone ();

		if (splited) {
			player.AddForce(new Vector3(Input.acceleration.normalized.x * speedSmall, 0, 0));
		} else {
			player.AddForce(new Vector3(Input.acceleration.normalized.x * speedBig, 0, 0));
		}



		if (Input.GetTouch (0).phase == TouchPhase.Began) {
			if (Input.GetTouch (0).position.x >= (Screen.width / 2) && grounded) {
				player.AddForce (new Vector3 (0, 2000, 0));
				grounded = false;
				audioManager.GetComponent<AudioManagingGame> ().jumpSound.Play ();
			} else if (Input.GetTouch (0).position.x < (Screen.width / 2) && splited == true) {
				if (PlayerPrefs.GetInt ("playerCount") != 1) {
					audioManager.GetComponent<AudioManagingGame> ().mergeSound.Play ();
					splitSymbol.GetComponent<SpriteRenderer> ().sprite = splitSprite;
				}
				mergeMitch ();

			}else if (Input.GetTouch (0).position.x < (Screen.width / 2) && splited == false){
				if (!onGameOver) {
					splited = true;
					if (PlayerPrefs.GetInt ("playerCount") != 1) {
						audioManager.GetComponent<AudioManagingGame>().popSound.Play();
						splitSymbol.GetComponent<SpriteRenderer>().sprite = unsplitSprite;
					}
					split ();

				}
			}

		}
		highlightMitch ();
		player.mass = 6;


//		if (Input.GetKeyDown(KeyCode.Space)){
//			//rb.velocity = new Vector2(0, jump);
//			player.AddForce(new Vector2(0,1000));
//		}
		if (player.position.x <= -100) {
			player.position = new Vector3 (0, 0, 0);
		} else if (player.position.y <= -100) {
			player.position = new Vector3 (0, 0, 0);
		} else if (player.position.y >= 400) {
			player.position = new Vector3 (0, 0, 0);
		}


	}

	void OnGUI(){
		//GUI.Box(new Rect(0, 0, 500, 500), ("grounded: " + grounded + " colliderInfo: " + colliderInfo));

	}

	void OnCollisionEnter2D (Collision2D collision){
		if (collision.gameObject.CompareTag ("Hindernisse")) {
			if (this.GetComponent<PlayerScript> ().isMain) {
				onGameOver = true;
				Time.timeScale = 0;
				gameoverScreen.GetComponent<SpriteRenderer> ().enabled = true;
				restartButton.gameObject.SetActive (true);
				homeButton.gameObject.SetActive (true);
				pauseButton.gameObject.SetActive (false);
			} else {
				Destroy (this.gameObject);
				int count = PlayerPrefs.GetInt ("playerCount");
				count = count - 1;
				PlayerPrefs.SetInt ("playerCount", count);
			}
		} else if (collision.gameObject.CompareTag ("Tür")) {
			PlayerPrefs.SetInt ("unlockedLevels",2);
			int currentScene = SceneManager.GetActiveScene ().buildIndex;
			SceneManager.UnloadSceneAsync (currentScene);
			SceneManager.LoadScene (4);
		} else if (collision.gameObject.CompareTag ("Boden")) {
			grounded = true;
		}
	}

	void split(){
		player.transform.localScale = new Vector3 (0.2924f*0.25f, 0.2924f*0.25f, 0.2924f*0.25f);
		float x = player.transform.position.x;
		float y = player.transform.position.y;
		float z = player.transform.position.z;

		int count = PlayerPrefs.GetInt ("playerCount");

		if (count == 4) {
			one = Instantiate<Rigidbody2D> (player, new Vector3 (x, y, z), player.transform.rotation);
			two = Instantiate<Rigidbody2D> (player, new Vector3 (x, y, z), player.transform.rotation);
			three = Instantiate<Rigidbody2D> (player, new Vector3 (x, y, z), player.transform.rotation);
		} else if (count == 3) {
			one = Instantiate<Rigidbody2D> (player, new Vector3 (x, y, z), player.transform.rotation);
			two = Instantiate<Rigidbody2D> (player, new Vector3 (x, y, z), player.transform.rotation);
		} else if (count == 2) {
			one = Instantiate<Rigidbody2D> (player, new Vector3 (x, y, z), player.transform.rotation);
		}

		one.GetComponent<PlayerScript> ().splited = true;
		one.GetComponent<PlayerScript>().isMain = false;
		two.GetComponent<PlayerScript> ().splited = true;
		two.GetComponent<PlayerScript>().isMain = false;
		three.GetComponent<PlayerScript> ().splited = true;
		three.GetComponent<PlayerScript>().isMain = false;
	}

	bool allowToMerge(){
		if (one.position.x - player.position.x > 5) {
			return false;
		} else if (two.position.x - player.position.x > 5) {
			return false;
		}else if (three.position.x - player.position.x > 5) {
			return false;
		}
		return true;
	}
}
