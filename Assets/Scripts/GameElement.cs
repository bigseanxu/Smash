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
	}

	public void OnGameRestart() {
		mScore.gameObject.SetActive (true);
		mStopButton.gameObject.SetActive (true);
	}
}
