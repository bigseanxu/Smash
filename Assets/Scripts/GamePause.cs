using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour {

	bool mIsPause = false;

	public Sprite [] mToBegin = new Sprite[14];
	public Sprite [] mToPause = new Sprite[14];	
	public bool mIsAni = false;

	// Use this for initialization
	void Start () {
	//	LeanTween.play((RectTransform)transform, mToPause).setFrameRate(24).setRepeat(1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnToggle() {
		print ("game pause 11 ");
		if (mIsAni) {
			return;
		}
		print ("game pause 22");
		mIsAni = true;
		mIsPause = !mIsPause;

		if (mIsPause) {
			LeanTween.play((RectTransform)transform, mToPause).setIgnoreTimeScale(true).setFrameRate(24).setRepeat(1).setOnComplete(OnTweenComplete);
			Time.timeScale = 0;	
		} else {
			LeanTween.play ((RectTransform)transform, mToBegin).setIgnoreTimeScale(true).setFrameRate(24).setRepeat(1).setOnComplete(OnTweenComplete);
				
		}
	}

	public void OnTweenComplete() {
		mIsAni = false;
		if (!mIsPause) {
			Time.timeScale = 1;	
		}
		
	}
}
