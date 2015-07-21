using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour {
	public Sprite mSwitchOn;
	public Sprite mSwitchOff;
	public Transform mSounds;

	bool mSoundSwitch = true;
	// Use this for initialization
	void Start () {

		Game.SoundSwitch = PlayerPrefs.GetInt ("sound", 1);
		if (Game.SoundSwitch == 1) {
			mSoundSwitch = true;
			GetComponent<Image> ().sprite = mSwitchOn;
			mSounds.gameObject.SetActive (true);
		} else {
			mSoundSwitch = false;
			GetComponent<Image> ().sprite = mSwitchOff;
			mSounds.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnToggle() {
		mSoundSwitch = !mSoundSwitch;
		mSounds.gameObject.SetActive (mSoundSwitch);
		if (mSoundSwitch) {
			GetComponent<Image> ().sprite = mSwitchOn;
			PlayerPrefs.SetInt("sound", 1);
		} else {
			GetComponent<Image> ().sprite = mSwitchOff;
			PlayerPrefs.SetInt("sound", 0);
		}
	}
}
