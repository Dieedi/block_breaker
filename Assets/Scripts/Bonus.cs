using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {

	public Sprite[] bonusSprite;
	public enum BonusTypeList {Magnet, Laser, Fireball};
	public static bool bonusActivated = false;
	public static float bonusTimeLeft = 5;

	private BonusTypeList bonusType;
	private Color[] colors = { new Color32(112,180,110,255), new Color32(112,180,190,255), new Color32(237,180,110,255)};

	// Use this for initialization
	void Start () {
		bonusType = (BonusTypeList)Random.Range(0, 3);
		AssignSprite ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void AssignSprite() {
		SpriteRenderer bonusRenderer = this.GetComponent<SpriteRenderer> ();
		bonusRenderer.sprite = bonusSprite [(int)bonusType];
		bonusRenderer.color = colors [(int)bonusType];
	}

	void AssignBonus() {
		bonusActivated = true;
		switch (bonusType) {
			case BonusTypeList.Magnet:
				Paddle.autoPlay = true;
				break;
			case BonusTypeList.Laser:
				print ("laser");
				break;
			case BonusTypeList.Fireball:
				var bricks = GameObject.FindGameObjectsWithTag ("Breakable");

				foreach (GameObject brick in bricks) {
					brick.GetComponent<BoxCollider2D> ().isTrigger = true;
				}
				break;
		}
	}

	public void CancelBonus() {
		bonusActivated = false;
		switch (bonusType) {
		case BonusTypeList.Magnet:
			Paddle.autoPlay = false;
			break;
		case BonusTypeList.Laser:
			print ("laser");
			break;
		case BonusTypeList.Fireball:
			var bricks = GameObject.FindGameObjectsWithTag ("Breakable");

			foreach (GameObject brick in bricks) {
				brick.GetComponent<BoxCollider2D> ().isTrigger = false;
			}
			break;
		}
	}

	void OnTriggerEnter2D (Collider2D trigger) {
		if (trigger.name == "Paddle"
				&& Ball.hasStarted == true 
				&& bonusActivated == false) {
			AssignBonus ();
		}
	}
}
