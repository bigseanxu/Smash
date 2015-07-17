using UnityEngine;
using System.Collections;

public class SquaresController : MonoBehaviour {

	public RectTransform mLeft;
	public RectTransform mRight;
	public Transform mJudge;

	public float mSmashInTime = 0.1f;
	public float mSmashOutTime = 0.5f;
	public int mSmashInEase = (int) LeanTweenType.linear;
	public int mSmashOutEase = (int) LeanTweenType.linear;

	public float mInterval = 0.2f;

	int mCurrHeight = 3;

	bool isSmashing;
	void Start () {

	}

	void Update () {
		if (mRight.anchoredPosition.x - mLeft.anchoredPosition.x - mLeft.rect.width <= Data.BallSize) {
			mJudge.GetComponent<Judge> ().SetEnable (true);
		} else {
			mJudge.GetComponent<Judge> ().SetEnable (false);
		}
	}

	public void SmashIn() {
		if (isSmashing) {
			return;
		}

		isSmashing = true;

		Vector2 leftSqureDest = ((RectTransform)mLeft).anchoredPosition;
		leftSqureDest.x = - ((RectTransform)mLeft).rect.width / 2.0f + 55 - 27.5f;
		LeanTween.move ((RectTransform)mLeft, leftSqureDest, mSmashInTime).setEase((LeanTweenType)mSmashInEase).setOnComplete (OnSmashInComplete);

		Vector2 rightSqureDest = ((RectTransform)mRight).anchoredPosition;
		rightSqureDest.x = ((RectTransform)mRight).rect.width / 2.0f - 55 + 27.5f;
		LeanTween.move ((RectTransform)mRight, rightSqureDest, mSmashInTime).setEase((LeanTweenType)mSmashInEase);
	}

	void OnSmashInComplete() {
		StartCoroutine (SmashOutCoroutine());
	}

	IEnumerator SmashOutCoroutine() {
		yield return new WaitForSeconds (mInterval);
		SmashOut ();
	}

	void SmashOut() {
		Vector2 leftSqureDest = ((RectTransform)mLeft).anchoredPosition;
		leftSqureDest.x = - 540 + ((RectTransform)mLeft).rect.width / 2.0f;
		LeanTween.move ((RectTransform)mLeft, leftSqureDest, mSmashOutTime).setEase((LeanTweenType)mSmashOutEase);


		Vector2 rightSqureDest = ((RectTransform)mRight).anchoredPosition;
		rightSqureDest.x = 540 - ((RectTransform)mRight).rect.width / 2.0f;
		LeanTween.move ((RectTransform)mRight, rightSqureDest, mSmashOutTime).setEase((LeanTweenType)mSmashOutEase).setOnComplete(OnSmashOutComplete);
	}

	void OnSmashOutComplete() {
		isSmashing = false;
	}

	public void LoseHeight() {
		if (mCurrHeight == 0) {
			return;
		}
		LeanTween.move ((RectTransform)mLeft.GetChild(mCurrHeight), new Vector2(-2000, 0), 1);
		LeanTween.move ((RectTransform)mRight.GetChild(mCurrHeight), new Vector2(2000, 0), 1);
		Vector2 vec = mLeft.sizeDelta;
		vec.y -= 84;
		mLeft.sizeDelta = vec;
		mCurrHeight -= 1;

	}

	public void RetainHeight() {
		mLeft.sizeDelta = new Vector2(198, 396);
		for (int i = mCurrHeight; i < 3; i++) {
			LeanTween.move ((RectTransform)mLeft.GetChild(i), new Vector2(-55, 0), 1);
			LeanTween.move ((RectTransform)mRight.GetChild(i), new Vector2(55, 0), 1);
		}
	}
}
