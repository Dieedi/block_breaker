using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	void OnTriggerEnter2D (Collider2D trigger) {
		if (trigger.name == "Ball") {
			/*
			if (Bonus.bonusActivated) {
				Bonus.CancelBonus ();
			}
*/
			var bonuses = GameObject.FindGameObjectsWithTag ("Bonus");

			foreach (GameObject bonus in bonuses) {
				Destroy (bonus);
			}

			levelManager = GameObject.FindObjectOfType<LevelManager> ();
			LevelManager.Lives--;

			LevelTexts.livesCount.GetComponent<Text> ().text = LevelManager.Lives.ToString ();

			if (LevelManager.Lives <= 0) {
				levelManager.LoadLevel ("lose");
			} else {
				Ball.hasStarted = false;
			}
		}
	}
}
