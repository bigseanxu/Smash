using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackGround : MonoBehaviour {
	public Color [] mColors;
	int mScore = 0;
	int mScoreCount = 0;
	int mCurrColor = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Game.CurrentScore == 0) {
			mScoreCount = 0;
		}
		mScore = Game.CurrentScore;
		if (mScore - mScoreCount == 10) {

			mCurrColor++;
			if (mCurrColor > mColors.Length - 1) {
				mCurrColor = 0;
			}

			LeanTween.color((RectTransform)transform, mColors[mCurrColor], 1.5f).setEase(LeanTweenType.easeInOutCubic);
			mScoreCount = mScore;
			//print (mColors[mCurrColor]);
			Game.CurrentColor = mCurrColor;
		}
	}
}
