using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Ball : MonoBehaviour {

	float mVelocity;
	public int mState = 0; // 0: normal, 1: smash,  2:crash
	bool mIsSmash;
	float mDeltaY;
	public RectTransform mLeftSquare;
	public Transform mGameController;
	bool mIsStart = false;
	bool isBomb;
	int mChickType = 0;// 0: yellow 1: blue 2: green 3: duck
	
	public float mHorSpeed;
	public float mG;

	public Sprite mImageCrash;
	// Use this for initialization
	void Start () {
		mIsStart = true;
	}
	
	// Update is called once per frame
	float t = 0;
	void Update () {
		if (mState == 0) {
			RectTransform rt = (RectTransform)transform;
			Vector2 v = rt.anchoredPosition;
			mDeltaY = mVelocity * Time.deltaTime;
			v.y += mDeltaY;
			((RectTransform)transform).anchoredPosition = v;
			if (v.y > 960) {
				if (!isBomb) {
					mState = 2;
					mGameController.GetComponent<GameController> ().GameOver ();
				}
			}
		} else if (mState == 2) {
			RectTransform rectTrans = (RectTransform)transform;
			if (!isBomb) {
				float t2 = t + Time.deltaTime;
				float s = 0.5f * mG * (t2 * t2 - t * t);
				t = t2;
				Vector2 vec = rectTrans.anchoredPosition;
				vec.x += mHorSpeed * Time.deltaTime;
				vec.y += s;
				rectTrans.anchoredPosition = vec;

			}
		}
	}

	void LateUpdate() {

	}

	public bool CheckCrash() {
		if (!mIsStart) {
			return false;
		}
		bool ret = false;
		RectTransform rt = (RectTransform)transform;
		if (rt.anchoredPosition.y + rt.rect.yMax > mLeftSquare.anchoredPosition.y + mLeftSquare.rect.yMin) {
			if (rt.anchoredPosition.y + rt.rect.yMax - mDeltaY <= mLeftSquare.anchoredPosition.y + mLeftSquare.rect.yMin) {
				float y = mLeftSquare.anchoredPosition.y + mLeftSquare.rect.yMin - rt.rect.yMax;
				rt.anchoredPosition = new Vector2(0, y - 0.01f); // minus 0.01f to ignore float deviation
				mState = 2;
				ret = true;
			}
		}
		return ret;
	}

	public void SetVelocity(float v) {
		mVelocity = v;
	}

	public void OnGetSmash() {
		if (isBomb) {
			mGameController.GetComponent<GameController> ().GameOver ();
		} else {
			Game.CurrentScore++;
			GameObject.Destroy (gameObject);
		}
	}

	public void OnCrash() {
		if (!isBomb) {
			GetComponent<Image>().sprite = mImageCrash;
		}
		mGameController.GetComponent<GameController> ().GameOver ();
	}

	public void SetIsBomb(bool bomb) {
		isBomb = bomb;
	}
	
	public bool IsBomb () {
		return isBomb;
	}
}
