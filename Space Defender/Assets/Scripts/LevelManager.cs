using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Application.LoadLevel (name);
	}

	public void NextLevel(){
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void QuitRequest(){
		Application.Quit (); // should not be used in apps or web applications
	}

}