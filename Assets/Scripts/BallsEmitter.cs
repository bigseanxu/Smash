using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BallsEmitter : MonoBehaviour {

	public Transform mBallsContainer;
	public float mInterval = 2f;
	public Transform mPrefab;
	public float mSpeed;
	public Transform mGameController;
	public RectTransform mLeftSquare;
	public float mBombChance;
	public Sprite mBomb;
	// ball settings
	public Vector3 mDefaultStartPosition;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	
	}


	public void StartEmitting() {
		StartCoroutine (Emit ());
	}

	IEnumerator EmitDelay() {
		yield return new WaitForSeconds (1);
		StartCoroutine (Emit());
	}

	IEnumerator Emit() {
		RectTransform ball = ((RectTransform)GameObject.Instantiate (mPrefab, Vector3.zero, Quaternion.Euler(0, 0, Random.Range(0, 360))));
		ball.SetParent (mBallsContainer);
		ball.localScale = Vector3.one;
		ball.anchoredPosition3D = mDefaultStartPosition;
		ball.GetComponent<Ball> ().SetVelocity(mSpeed);
		ball.GetComponent<Ball> ().mGameController = mGameController;
		ball.GetComponent<Ball> ().mLeftSquare = mLeftSquare;

		float r = Random.value;
		if (r < mBombChance) {
			ball.GetComponent<Ball> ().isBomb = true;
			ball.GetComponent<Image>().sprite = mBomb;
		}

		yield return new WaitForSeconds (mInterval);

		if (Game.status == 1) {
			StartCoroutine (Emit());
		}

	}

	public void OnPause () {

	}

	public void OnResume() {

	}

	public void OnGameOver() {
		for (int i = 0; i < mBallsContainer.childCount; i++) {
			GameObject.Destroy(mBallsContainer.GetChild(i).gameObject);
		}
	}
}
