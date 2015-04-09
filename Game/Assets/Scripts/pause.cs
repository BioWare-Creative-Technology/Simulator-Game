using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pause : MonoBehaviour {

	public GameObject playerCanvas;
	public GameObject pauseCanvas;
	public GameObject isExit;

	public Text tips_right;
	public Text tips_left;

	public const int ElementNumber = 10;

	public string[] tips = new string[ElementNumber];

	public bool isPaused = false;

	// Use this for initialization
	void Start () {
		isPaused = false;
		pauseCanvas.SetActive (false);
		playerCanvas.SetActive (true);
		isExit.SetActive (false);
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPaused == false) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				isPaused = true;

				int tip1 = Random.Range(0,(ElementNumber - 1));
				int tip2 = Random.Range(0,(ElementNumber - 1));

				if(tip1 == tip2){
					tip2 = Random.Range(0,(ElementNumber - 1));
				}
				tips_right.text = tips [tip2];
				tips_left.text = tips [tip1];
			}
		} else {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				isPaused = false;	
			}
		}

		if (isPaused == true) {
			playerCanvas.SetActive (false);
			pauseCanvas.SetActive (true);
			Time.timeScale = 0;
			Cursor.visible = true;
		} else {
			playerCanvas.SetActive (true);
			pauseCanvas.SetActive (false);
			Time.timeScale = 1;
			Cursor.visible = false;
		}


	}

	public void Resume(){
		playerCanvas.SetActive (true);
		pauseCanvas.SetActive (false);
		Time.timeScale = 1;
		Cursor.visible = false;
		isPaused = false;
	}

	public void ExitToMenu(){
		Application.LoadLevel ("mainMenu");
	}

	public void ExitToDesktop(){
		isExit.SetActive (true);
	}

	public void trueExit(){
		Application.Quit ();
	}

	public void falseExit(){
		isExit.SetActive (false);
	}
}
