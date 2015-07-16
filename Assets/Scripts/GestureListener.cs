using UnityEngine;
using System.Collections;

public class GestureListener : MonoBehaviour {

	public Transform mBallsEmitter;
	public Transform mSquares;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTap(TapGesture gesture) { 
		if (Game.status == 1) {
			mSquares.GetComponent<SquaresController> ().SmashIn ();
		}
	}
}
