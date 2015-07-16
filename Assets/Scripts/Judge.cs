using UnityEngine;
using System.Collections;

public class Judge : MonoBehaviour {

	public RectTransform mSqures;
	public RectTransform mBalls;
	public RectTransform mLeftSqure;
	
	bool mEnable = false;

	void Start () {

	}

	void Update () {

	}

	void LateUpdate() {
		if (Game.status != 1) {
			return;
		}
		if (mEnable) {
			for (int i = 0; i < mBalls.childCount; i++) {
				RectTransform rt = (RectTransform)mBalls.GetChild(i);
				if (rt.GetComponent<Ball>().CheckCrash()) {
					rt.GetComponent<Ball>().OnCrash();
				} else {
					int dect = DetectCollision(rt);
					if (dect == 1) {
						rt.GetComponent<Ball>().OnGetSmash();
					}
				}
			}
		}
	}

	public void SetEnable(bool enable) {
		mEnable = enable;
	}

	// 0: no overlaps
	// 1: smash
	// 2: crash
	int DetectCollision(RectTransform ball) {
		// Cause the ball is in the center of the screen,
		// so we just need to detect the collision between the ball and the left squre.
		int ret = 0;

		if (ball.anchoredPosition.y + ball.rect.yMax > mLeftSqure.anchoredPosition.y + mLeftSqure.rect.yMin && 
			ball.anchoredPosition.y + ball.rect.yMin < mLeftSqure.anchoredPosition.y + mLeftSqure.rect.yMax) {
			ret = 1;
		}

		return ret;
	}


}
