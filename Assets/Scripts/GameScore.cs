﻿using UnityEngine;
using System.Collections;

public class GameScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<ShowNumberInCanvas> ().SetNumber (Game.CurrentScore);
	}

	void OnEnable() {

	}
}
