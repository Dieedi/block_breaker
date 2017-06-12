using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public static bool autoPlay = false;

	private Ball ball;
	private float paddleMinX = 0.67f;
	private float paddleMaxX = 15.33f;
	//private bool hasBonus = false;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay ();
		}
	}

	void MoveWithMouse() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);

		float mouseX = Input.mousePosition.x / Screen.width * 16;
		paddlePos = new Vector3(Mathf.Clamp(mouseX, paddleMinX, paddleMaxX), this.transform.position.y, 0f);
		this.transform.position = paddlePos;
	}

	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);

		float ballPosX = ball.transform.position.x;
		paddlePos = new Vector3(Mathf.Clamp(ballPosX, paddleMinX, paddleMaxX), this.transform.position.y, 0f);
		this.transform.position = paddlePos;
	}
}
