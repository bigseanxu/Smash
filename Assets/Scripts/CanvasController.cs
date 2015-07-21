using UnityEngine;
using System.Collections;

public class CanvasController : MonoBehaviour {

	public RectTransform mStartPage;
	public RectTransform mGameElement;
	public RectTransform mGameOver;

	public GameController mGameController;
	public Transform mBallsEmitter;

	public Transform mPageSound;
	
	// Use this for initialization
	void Start () {
		print ("canvas start");
		Game.Init ();
		mGameElement.anchoredPosition = new Vector2 (1400, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGameStart() {
		mPageSound.GetComponent<AudioSource> ().Play ();
		LeanTween.move (mStartPage, new Vector2 (-1400, 0), 0.5f).setEase(LeanTweenType.easeInCubic).setOnComplete (OnGameStartTweenComplete);
		LeanTween.move (mGameElement, new Vector2(0, 0), 0.5f).setEase(LeanTweenType.easeInCubic);
//		mStartPage.gameObject.SetActive (false);
//		mGameElement.gameObject.SetActive (true);
	}	

	public void OnGameOver() {
		StartCoroutine (PlayGameOverAni());
		mGameOver.GetComponent<GameOverPage> ().SetScore ();
	}

	IEnumerator PlayGameOverAni() {
		yield return new WaitForSeconds (2);
		mPageSound.GetComponent<AudioSource> ().Play ();
		LeanTween.move (mGameOver, new Vector2 (0, 0), 0.5f).setEase (LeanTweenType.easeInCubic).setOnComplete (OnGameOverTweenComplete);
		mGameElement.GetComponent<GameElement> ().OnGameOver ();
	}

	public void OnGameRestart() {
		mPageSound.GetComponent<AudioSource> ().Play ();
		LeanTween.move (mGameOver, new Vector2(1080, 0), 0.5f).setEase(LeanTweenType.easeInCubic).setOnComplete (OnGameRestartTweenComplete);

	}

	public void OnGameStartTweenComplete() {
		mBallsEmitter.GetComponent<BallsEmitter> ().StartEmitting ();
		Game.status = 1;
	}

	public void OnGameOverTweenComplete() {
		mBallsEmitter.GetComponent<BallsEmitter> ().OnGameOver ();
		mGameOver.GetComponent<GameOverPage> ().PlayNewBestSound ();
	}

	public void OnGameRestartTweenComplete() {
		mBallsEmitter.GetComponent<BallsEmitter> ().StartEmitting ();
		mGameElement.GetComponent<GameElement> ().OnGameRestart ();
		Game.status = 1;
	}
}
