using UnityEngine;
using System.Collections;

public class GameScore : MonoBehaviour {
	bool mIsAni = false;
	int mScore = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Game.CurrentScore == 0) {
			GetComponent<ShowNumberInCanvas> ().SetNumber (Game.CurrentScore);
		} else {
			if (mScore != Game.CurrentScore) {
				mScore = Game.CurrentScore;
				BeBig();
			}
		}

	}

	void OnEnable() {

	}

	void BeBig() {
		GetComponent<Animator> ().Play ("ScoreAni", -1, 0);	
	}

	public void SetScore() {
		GetComponent<ShowNumberInCanvas> ().SetNumber (Game.CurrentScore);
	}
}
