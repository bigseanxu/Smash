using UnityEngine;
using System.Collections;

public class GameElement : MonoBehaviour {

	public Transform mScore;
	public Transform mStopButton;
	public Transform mSquare;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGameOver() {
		mSquare.GetComponent<SquaresController> ().RetainHeight ();
		mScore.gameObject.SetActive (false);
		mStopButton.gameObject.SetActive (false);
		Game.total+=Game.CurrentScore;
		PlayerPrefs.SetInt("total",Game.total);
		PlayerPrefs.SetInt("yellow",Game.yellow);
		PlayerPrefs.SetInt("duck",Game.duck);
		PlayerPrefs.SetInt("blue",Game.blue);
		PlayerPrefs.SetInt("green",Game.green);
		PlayerPrefs.SetInt("boom",Game.boom);
	}

	public void OnGameRestart() {
		mScore.gameObject.SetActive (true);
		mStopButton.gameObject.SetActive (true);
	}
}
