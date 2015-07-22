using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainPageBackGround : MonoBehaviour {
	public Transform mBackGround;

	// Use this for initialization
	void Start () {
		GetComponent<Image> ().color = mBackGround.GetComponent<BackGround> ().mColors[Game.CurrentColor];
		mBackGround.GetComponent<Image>().color = mBackGround.GetComponent<BackGround> ().mColors[Game.CurrentColor];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
