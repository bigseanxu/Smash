using UnityEngine;
using System.Collections;

public class CanvasController : MonoBehaviour {

	public RectTransform mStartPage;
	public RectTransform mGameElement;
	public RectTransform mGameOver;

	public GameController mGameController;
	public Transform mBallsEmitter;
	
	// Use this for initialization
	void Start () {
		print (mGameElement.anchoredPosition);
		mGameElement.anchoredPosition = new Vector2 (1240, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGameStart() {
		LeanTween.move (mStartPage, new Vector2 (-1240, 0), 0.5f).setEase(LeanTweenType.easeInCubic).setOnComplete (OnGameStartTweenComplete);
		LeanTween.move (mGameElement, new Vector2(0, 0), 0.5f).setEase(LeanTweenType.easeInCubic);
//		mStartPage.gameObject.SetActive (false);
//		mGameElement.gameObject.SetActive (true);
	}	

	public void OnGameOver() {
		StartCoroutine (PlayGameOverAni());
	}

	IEnumerator PlayGameOverAni() {
		yield return new WaitForSeconds (2);
		LeanTween.move (mGameOver, new Vector2 (0, 0), 0.5f).setEase (LeanTweenType.easeInCubic).setOnComplete (OnGameOverTweenComplete);
	}

	public void OnGameRestart() {
		LeanTween.move (mGameOver, new Vector2(1080, 0), 0.5f).setEase(LeanTweenType.easeInCubic).setOnComplete (OnGameRestartTweenComplete);
	}

	public void OnGameStartTweenComplete() {
		mBallsEmitter.GetComponent<BallsEmitter> ().StartEmitting ();
		Game.status = 1;
	}

	public void OnGameOverTweenComplete() {
		mBallsEmitter.GetComponent<BallsEmitter> ().OnGameOver ();

	}

	public void OnGameRestartTweenComplete() {
		mBallsEmitter.GetComponent<BallsEmitter> ().StartEmitting ();
		Game.status = 1;
	}
}
