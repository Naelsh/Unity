using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null; // define an instance of the class as a static member. Give it no value

	void Awake(){ // destroying on awake since it executes before Start.
		if (instance != null) { // destroying multiple instances of the music player
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this; // set the newly created object to be the instance. Thus not null any more.
			GameObject.DontDestroyOnLoad(gameObject); // don't destory this instance when we load a level
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

// method call order
// 1. Awake
// 2. Start
// 3. Update