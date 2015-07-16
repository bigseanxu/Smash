using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	float mVelocity;
	public int mState = 0; // 0: normal, 1: smash,  2:crash
	bool mIsSmash;
	float mDeltaY;
	public RectTransform mLeftSquare;
	public Transform mGameController;
	bool mIsStart = false;
	public bool isBomb;
	// Use this for initialization
	void Start () {
		mIsStart = true;
	}
	
	// Update is called once per frame
	void Update () {
	//	if (Game.status == 1) {
			if (mState == 2) {
				return;
			}
			RectTransform rt = (RectTransform)transform;
			Vector2 v = rt.anchoredPosition;
			mDeltaY = mVelocity * Time.deltaTime;
			v.y += mDeltaY;
			((RectTransform)transform).anchoredPosition = v;
			
			if (v.y > 960) {
				GameObject.Destroy(gameObject);
			}
//		}
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
			GameObject.Destroy (gameObject);
		}
	}

	public void OnCrash() {
		mGameController.GetComponent<GameController> ().GameOver ();
	}
}
