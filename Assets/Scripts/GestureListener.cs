using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GestureListener : MonoBehaviour {

	public Transform mBallsEmitter;
	public Transform mSquares;
	public Transform mGamePause;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTap(TapGesture gesture) { 
		if (Game.status == 1) {
			if (mGamePause.GetComponent<GamePause>().mIsAni) {
				return;
			}
			mSquares.GetComponent<SquaresController> ().SmashIn ();
		}
	}
}
