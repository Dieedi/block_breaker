using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public static int Lives = 3;

	private int Score;
	private float StartTimer;
	private float Timer;

	void Start () {
		Score = 0;
		StartTimer = 120; // in seconds
		if (SceneManager.GetActiveScene ().buildIndex >= 1 && SceneManager.GetActiveScene ().buildIndex < 5) {
			LevelTexts.timer.GetComponent<Text> ().text = StartTimer.ToString ();
		}
	}

	void Update () {
		/*
		if (Bonus.bonusActivated) {
			print ("bonus active");
			Bonus.bonusTimeLeft -= Time.deltaTime;
			if (Bonus.bonusTimeLeft < 0) {
				Bonus.CancelBonus();
			}
		}
*/
		if (SceneManager.GetActiveScene ().buildIndex >= 1 && SceneManager.GetActiveScene ().buildIndex < 5) {
			LevelTexts.livesCount.GetComponent<Text> ().text = Lives.ToString ();
		}

		if (Ball.hasStarted) {
			Timer = StartTimer - Mathf.FloorToInt (Time.timeSinceLevelLoad);

			if (Timer <= 0) {
				LevelTexts.timer.GetComponent<Text> ().text = "0";
			} else {
				LevelTexts.timer.GetComponent<Text> ().text = Timer.ToString ();
			}
		}
	}

	// Use this for initialization
	public void LoadLevel (string name) {
		Brick.breackableCount = 0;
		Ball.hasStarted = false;
		SceneManager.LoadScene (name);
	}

	public void QuitRequest () {
		// not good for phone app !!!!
		Application.Quit();
	}

	public void LoadNextLevel() {
		Brick.breackableCount = 0;
		StartTimer = 120;
		Ball.hasStarted = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void BrickDestroyed() {
		if (Brick.breackableCount <= 0) {
			LoadNextLevel();
		}

		Score = Score + 10;
		LevelTexts.score.GetComponent<Text> ().text = Score.ToString ();
	}
}
