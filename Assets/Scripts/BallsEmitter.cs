using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BallsEmitter : MonoBehaviour {

	public Transform mSquaresController;
	public Transform mBallsContainer;
	public Transform mPrefab;
	public Transform mGameController;
	public RectTransform mLeftSquare;
	public Sprite mBomb;

	float mTime = 0;
	float mCurrWave = 0;
	float mCurrWaveBallCount = 0;
	float mCurrBallInWave = 0;
	int mStatus = 0; // 0: not started, 1: started
	// ball settings
	public Vector3 mDefaultStartPosition;
	public float mInterval = 2f;
	public float mBombChance;
	public float mSpeed;
	public float mMinSpeed;
	public float mMaxSpeed;
	public float mMinWaveTime;
	public float mMaxWaveTime;
	public int mMinBallsPerWave;
	public int mMaxBallsPerWave;
	public float mIntervalBetweenWaves;
	public float mMinIntervalBetweenBalls;
	public float mMaxIntervalBetweenBalls;
	public int mWaveToLoseHeight1;
	public int mWaveToLoseHeight2;
	public int mWaveToLoseHeight3;



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}


	public void StartEmitting() {
		if (mStatus != 1) {
			mStatus = 1;
			StartCoroutine (StartWave());
		}
	}

	IEnumerator StartWave() {
		print ("curr wave = " + mCurrWave);
		mCurrWaveBallCount = Random.Range (mMinBallsPerWave, mMaxBallsPerWave);
		StartCoroutine (Emit ());
		yield return null;
	}

	IEnumerator EmitDelay() {
		yield return new WaitForSeconds (1);

	}

	IEnumerator Emit() {
		if (mCurrBallInWave == mCurrWaveBallCount) {
			if (mCurrWave == mWaveToLoseHeight1 || mCurrWave == mWaveToLoseHeight2 || mCurrWave == mWaveToLoseHeight3) {
				mSquaresController.GetComponent<SquaresController>().LoseHeight();
			}

			yield return new WaitForSeconds (mIntervalBetweenWaves);

			mCurrWave++;
			StartCoroutine (StartWave ());
			yield return null;
		} else {
			RectTransform ball = ((RectTransform)GameObject.Instantiate (mPrefab, Vector3.zero, Quaternion.Euler(0, 0, Random.Range(0, 360))));
			ball.SetParent (mBallsContainer);
			ball.localScale = Vector3.one;
			ball.anchoredPosition3D = mDefaultStartPosition;
			ball.GetComponent<Ball> ().SetVelocity(Random.Range(mMinSpeed, mMaxSpeed));
			ball.GetComponent<Ball> ().mGameController = mGameController;
			ball.GetComponent<Ball> ().mLeftSquare = mLeftSquare;
			
			float r = Random.value;
			if (r < mBombChance) {
				ball.GetComponent<Ball> ().SetIsBomb(true);
				ball.GetComponent<Image>().sprite = mBomb;
			}
			
			mCurrBallInWave++;
			
			yield return new WaitForSeconds (Random.Range(mMinIntervalBetweenBalls, mMaxIntervalBetweenBalls));
			
			if (Game.status == 1) {
				StartCoroutine (Emit());
			}

		}
	}

	public void OnPause () {

	}

	public void OnResume() {

	}

	public void OnRestart() {
		mCurrWave = 0;
		mCurrWaveBallCount = 0;
		mCurrBallInWave = 0;
	}

	public void OnGameOver() {
		for (int i = 0; i < mBallsContainer.childCount; i++) {
			GameObject.Destroy(mBallsContainer.GetChild(i).gameObject);
		}
		mStatus = 0;
	}
}
