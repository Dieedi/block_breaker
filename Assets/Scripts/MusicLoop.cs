using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicLoop : MonoBehaviour {

	static MusicLoop instance = null;

	void Awake() {
		if (instance != null && instance.name != this.name) {
			GameObject.Destroy (GameObject.Find(instance.name));
		} else if (instance != null) {
			GameObject.Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
