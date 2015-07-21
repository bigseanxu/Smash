using UnityEngine;
using System.Collections;

public class GameOverPage : MonoBehaviour {
	public Transform mHighScore;
	public Transform mYourScore;
	public Transform mNewBestSound;

	bool mIsNewBest = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetScore() {
		mHighScore.GetComponent<ShowNumberInCanvas> ().SetNumber (Game.HighScore);
		mYourScore.GetComponent<ShowNumberInCanvas> ().SetNumber (Game.CurrentScore);
		if (Game.HighScore < Game.CurrentScore) {
			mIsNewBest = true;
		} else {
			mIsNewBest = false;
		}
	}

	public void PlayNewBestSound() {
		if (mIsNewBest) {
			mNewBestSound.GetComponent<AudioSource>().Play();
		}
	}
}
