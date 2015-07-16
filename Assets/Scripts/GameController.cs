using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public Transform mCanvas;
	public Transform mBallsEmitter;

	bool gameStartPressed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame() {
		if (!gameStartPressed) {
			mCanvas.GetComponent<CanvasController> ().OnGameStart ();
			gameStartPressed = true;
		}
	}

	public void GameOver() {
		if (Game.status == 1) {
			mCanvas.GetComponent<CanvasController> ().OnGameOver ();
			Game.status = 3;
		}

	}

	public void GameRestart() {
		mCanvas.GetComponent<CanvasController> ().OnGameRestart ();
		mBallsEmitter.GetComponent<BallsEmitter> ().OnRestart();
	}
	
}
