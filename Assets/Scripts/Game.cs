using UnityEngine;
using System.Collections;

public static class Game
{
	public static int status = 0; // 0: welcome. 1: in game 2: pause 3: game over
	public static int CurrentScore = 0;
	public static int HighScore = 0;
	public static bool NewBest = false;
	public static int SoundSwitch = 0;

	public static void Init() {
		HighScore = PlayerPrefs.GetInt ("best", 0);
		SoundSwitch = PlayerPrefs.GetInt ("sound", 1);
		CurrentScore = 0;
		NewBest = false;
	}
}

