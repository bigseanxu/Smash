using UnityEngine;
using System.Collections;

public class BombBomb : MonoBehaviour {
	
	public Sprite [] mImages;
	bool mIsPlaying = false;

	// Use this for initialization
	void Start () {
		mImages = Resources.LoadAll<Sprite> ("BomkSmoke");
//		for (int i = 0; i < mImages.Length; i++) {
//			string suffix;
//			if (i < 10) {
//				suffix = "0" + (i + 1);
//			} else {
//				suffix = "" + (i + 1);
//			}
//			mImages[i] = Resources.Load<Sprite>("BomkSmoke/BomkSmoke_" + suffix + ".png");
//		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Play() {
		mIsPlaying = true;
		LeanTween.play ((RectTransform)transform, mImages).setFrameRate(25).setRepeat(1).setOnComplete(OnTweenComplete);
	}

	void OnTweenComplete() {
		((RectTransform)transform).anchoredPosition3D = new Vector3 (0, -2000, 0);
	}

	public void Reset () {

	}
}
