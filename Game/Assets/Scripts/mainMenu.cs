using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mainMenu : MonoBehaviour {
	
	public GameObject mainMenuCanvas;
	public GameObject loadingCanvas;
	public GameObject Credits;
	public GameObject ProgressBar;
	public Text loadingText;
	public GameObject quitBox;
	public string levelToLoad;
	public string MultiplayerLoad;
	public GameObject Updates;
	public GameObject main;
	public GameObject SecondScreen;
	private int loadProgress = 0;
	
	//other gameobject vars
	public GameObject Create;
	public GameObject Search;

	public Text creditUpdate;

	private bool isCredit = false;
	
	
	// Use this for initialization
	void Start () {
		loadingCanvas.SetActive (false);
		mainMenuCanvas.SetActive (true);
		quitBox.SetActive (false);
		Credits.SetActive (false);
		isCredit = false;
	}
	
	void Update () {
		
	}
	
	public void Play(){
		SecondScreen.SetActive (true);
		main.SetActive (false);
	}

	public void back(){
		SecondScreen.SetActive (false);
		main.SetActive (true);
	}
	
	public void Options(){

	}
	
	public void SearchLoad(){
		Search.SetActive (true);
		Create.SetActive (false);
	}
	
	public void CreateLoad(){
		Create.SetActive (true);
		Search.SetActive (false);
	}
	
	public void Exit(){
		quitBox.SetActive (true);
	}
	public void Multiplayer(){
		Application.LoadLevel (MultiplayerLoad);
	}
	
	public void credits(){
		if (isCredit == true) {
			Credits.SetActive(false);
			Updates.SetActive(true);
			isCredit = false;
			creditUpdate.text = "Credits";
		} else {
			Credits.SetActive(true);
			Updates.SetActive(false);
			isCredit = true;
			creditUpdate.text = "Updates";
		}
	}
	
	public void realExit(){
		Application.Quit ();
	}
	
	public void denyExit(){
		quitBox.SetActive (false);
	}

	public void playOffline(){
		StartCoroutine(DisplayLoadingScreen(levelToLoad));
	}
	IEnumerator DisplayLoadingScreen(string level){
		
		loadingCanvas.SetActive (true);
		mainMenuCanvas.SetActive (false);
		
		loadingText.text = "Loading is " + loadProgress + "% done.";	
		ProgressBar.transform.localScale = new Vector3(loadProgress,ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);	
		
		AsyncOperation async = Application.LoadLevelAsync(level);	
		while (!async.isDone) {
			
			loadProgress = (int)(async.progress * 100);	
			
			loadingText.text = "Loading is " + loadProgress + "% done;";	
			ProgressBar.transform.localScale = new Vector3(loadProgress,ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);
			
			yield return null;
		}
		
	}
}
