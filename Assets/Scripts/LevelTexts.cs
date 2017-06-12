using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTexts : MonoBehaviour {

	private GameObject levelName;
	public static GameObject score;
	public static GameObject timer;
	public static GameObject livesCount;

	// Use this for initialization
	void Start () {
		int sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		levelName = GameObject.Find ("LevelName");
		score = GameObject.Find ("ScoreCount");
		timer = GameObject.Find ("Timer");
		livesCount = GameObject.Find ("LivesCount");

		levelName.GetComponent<Text>().text = "level " + sceneIndex;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
