using UnityEngine;
using System.Collections;

public class GameOverPage : MonoBehaviour {
	public Transform mHighScore;
	public Transform mYourScore;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mHighScore.GetComponent<ShowNumberInCanvas> ().SetNumber (Game.HighScore);
		mYourScore.GetComponent<ShowNumberInCanvas> ().SetNumber (Game.CurrentScore);
	}
}
