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
	bool isCrashed = false;
	int mChickType = 0;// 0: yellow 1: duck 2: green 3: blue
	
	public float mHorSpeed;
	public float mG;

	public Sprite[] mImageNormal = new Sprite[4];
	public Sprite [] mImageCrash = new Sprite [4];
	public Sprite [] mImageFeather = new Sprite [4];
	public Material[] mFeather = new Material[4];

	public ParticleSystem mSmashParticle;
	public ParticleSystem mCrashParticle;
	public ParticleSystem mBirthParticle;
	public ParticleSystem mBombParticle;
	public ParticleSystem mSmokeParticle;

	public RectTransform mBombBomb;
	public RectTransform mNoUI;
	public Transform mBombSound;
	public Transform mCrashSound;
	public Transform mSmashSound;
	// Use this for initialization
	void Start () {
		mIsStart = true;
		if (Random.value < 0.5f) {
			mHorSpeed = -mHorSpeed;
		}
		if (isBomb) {
//			mSmokeParticle.gameObject.SetActive(true);
			mBombParticle.gameObject.SetActive(true);
			mSmokeParticle.time = 10;
		}
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
					GetComponent<Image> ().sprite = mImageCrash [mChickType];
					mCrashParticle.gameObject.SetActive (true);
					mCrashParticle.Play ();
					mGameController.GetComponent<GameController> ().GameOver ();
					mNoUI.GetComponent<Animator>().Play("GameElementVibrate", -1, 0);
					mCrashSound.GetComponent<AudioSource>().Play();
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
		if (isCrashed) {
			return false;
		}
		bool ret = false;
		RectTransform rt = (RectTransform)transform;
		if (rt.anchoredPosition.y + rt.rect.yMax > mLeftSquare.anchoredPosition.y + mLeftSquare.rect.yMin) {
			if (rt.anchoredPosition.y + rt.rect.yMax - mDeltaY <= mLeftSquare.anchoredPosition.y + mLeftSquare.rect.yMin) {
				float y = mLeftSquare.anchoredPosition.y + mLeftSquare.rect.yMin - rt.rect.yMax;
				rt.anchoredPosition = new Vector2(0, y - 0.01f); // minus 0.01f to ignore float deviation
				mState = 2;
				mCrashParticle.gameObject.SetActive (true);
				mCrashParticle.Play ();
				ret = true;
			}
		}
		return ret;
	}

	public void SetVelocity(float v) {
		mVelocity = v;
	}

	public void OnGetSmash() {
		if (mState == 1) {
			return;
		}
		if (isBomb) {
			BombBomb();
			GetComponent<Image>().color = Vector4.zero;
			mBombParticle.gameObject.SetActive(false);
			mGameController.GetComponent<GameController> ().GameOver ();
		} else {
			Game.CurrentScore++;
			mSmashParticle.gameObject.SetActive(true);
			mSmashParticle.Play();
			GetComponent<Image>().color = new Color(0, 0, 0, 0);
			mSmashSound.GetComponent<AudioSource>().Play();
			//GameObject.Destroy (gameObject);
		}
		mState = 1;
	}

	public void OnCrash() {
		isCrashed = true;

		if (!isBomb) {
			GetComponent<Image> ().sprite = mImageCrash [mChickType];
			mCrashParticle.gameObject.SetActive (true);
			mCrashParticle.Play ();
			mCrashSound.GetComponent<AudioSource>().Play();
		} else {
			BombBomb();
			GetComponent<Image>().color = Vector4.zero;
			mBombParticle.gameObject.SetActive(false);
		}
		mGameController.GetComponent<GameController> ().GameOver ();
	}

	public void SetIsBomb(bool bomb) {
		isBomb = bomb;
	}
	
	public bool IsBomb () {
		return isBomb;
	}

	public int GetChick() {
		float r = Random.value;
		Image image = GetComponent <Image> ();
		if (r < 0.25f) {
			mChickType = 0;
		} else if (r < 0.5f) {
			mChickType = 1;
			image.sprite = mImageNormal [1];
		} else if (r < 0.75f) {
			mChickType = 2;
			image.sprite = mImageNormal [2];
			mSmashParticle.GetComponent<ParticleSystemRenderer>().material = mFeather[2];
			mCrashParticle.GetComponent<ParticleSystemRenderer>().material = mFeather[2];
		} else {
			mChickType = 3;
			image.sprite = mImageNormal [3];
			mSmashParticle.GetComponent<ParticleSystemRenderer>().material = mFeather[3];
			mCrashParticle.GetComponent<ParticleSystemRenderer>().material = mFeather[3];
		}
		return mChickType;
	}

	void BombBomb() {
		mBombSound.GetComponent<AudioSource> ().Play ();	
		mBombBomb.transform.position = transform.position;
		mBombBomb.GetComponent<BombBomb> ().Play ();
	}
}
