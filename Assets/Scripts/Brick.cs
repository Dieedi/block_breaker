using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public static int breackableCount = 0;
	public GameObject bonus;
	public GameObject smoke;

	private LevelManager levelmanager;
	private int timesHit;
	private int bricksCount;
	private bool isBreakable;
	private bool hasBonus;
	private int magnetBonusCount = 0;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");

		if (isBreakable) {
			breackableCount++;

			//if (Mathf.FloorToInt (Random.Range (0f, 1f) * 100) == 25 && magnetBonusCount == 0) {
				this.hasBonus = true;
				magnetBonusCount++;
			//}
		}

		levelmanager = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (isBreakable) {
			HandleHits ();
		}
	}

	void OnTriggerEnter2D (Collider2D trigger) {
		if (isBreakable && trigger.name == "Ball") {
			HandleHits ();
		}
	}

	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;

		if (timesHit >= maxHits) {
			breackableCount--;
			levelmanager.BrickDestroyed();
			Smog ();
			GameObject.Destroy (gameObject);

			if (this.hasBonus == true) {
				Instantiate (bonus, this.transform.position, Quaternion.identity);
			}
		} else {
			LoadSprites ();
		}
	}

	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}

	void Smog() {
		GameObject smokePuff = Instantiate (smoke, this.transform.position, Quaternion.identity);
		ParticleSystem.MainModule smokeEffect = smokePuff.GetComponent<ParticleSystem> ().main;
		smokeEffect.startColor = gameObject.GetComponent<SpriteRenderer> ().color;
	}
}
