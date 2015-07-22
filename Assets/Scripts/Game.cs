using UnityEngine;
using System.Collections;

public static class Game
{
	public static int status = 0; // 0: welcome. 1: in game 2: pause 3: game over
	public static int CurrentScore = 0;
	public static int HighScore = 0;
	public static bool NewBest = false;
	public static int SoundSwitch = 0;
	public static int yellow = PlayerPrefs.GetInt ("yellow", 0);
	public static int duck = PlayerPrefs.GetInt ("duck", 0);
	public static int blue = PlayerPrefs.GetInt ("blue", 0);
	public static int green = PlayerPrefs.GetInt ("green", 0);
	public static int boom = PlayerPrefs.GetInt ("boom", 0);
	public static int playtimes = PlayerPrefs.GetInt ("playtimes", 0);
	public static int total = PlayerPrefs.GetInt ("total", 0);
	public static int CurrentColor = 5;
	public static void Init() {
		HighScore = PlayerPrefs.GetInt ("best", 0);
		SoundSwitch = PlayerPrefs.GetInt ("sound", 1);
		CurrentScore = 0;
		NewBest = false;
	}
}

