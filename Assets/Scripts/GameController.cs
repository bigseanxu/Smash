using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public Transform mCanvas;
	public Transform mBallsEmitter;
	public Transform mBackgroundMusic;

	bool gameStartPressed = false;
	// Use this for initialization
	void Start () {

		mBackgroundMusic.GetComponent<AudioSource> ().Play ();
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
			if (Game.CurrentScore > Game.HighScore) {
				PlayerPrefs.SetInt("best", Game.CurrentScore);
				Game.NewBest = true;
			} else {
				Game.NewBest = false;
			}
			Game.status = 3;
		}
	}

	public void GameRestart() {
		mCanvas.GetComponent<CanvasController> ().OnGameRestart ();
		mBallsEmitter.GetComponent<BallsEmitter> ().OnRestart();
		Game.CurrentScore = 0;
		if (Game.NewBest) {
			Game.HighScore = PlayerPrefs.GetInt("best");
		}
	}

	public void Reload() {
		Application.LoadLevel (0);
	}
	
}
