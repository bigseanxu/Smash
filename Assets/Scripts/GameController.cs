using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public Transform mCanvas;
	public Transform mBallsEmitter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame() {
		mCanvas.GetComponent<CanvasController> ().OnGameStart ();
	}

	public void GameOver() {
		mCanvas.GetComponent<CanvasController> ().OnGameOver ();
		Game.status = 3;
	}

	public void GameRestart() {
		mCanvas.GetComponent<CanvasController> ().OnGameRestart ();
	}
	
}
