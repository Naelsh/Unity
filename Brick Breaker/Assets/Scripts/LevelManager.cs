using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Brick.breakableBricksInScene = 0;
		Application.LoadLevel (name);
	}

	public void NextLevel(){
		Brick.breakableBricksInScene = 0;
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void QuitRequest(){
		Application.Quit (); // should not be used in apps or web applications
	}

	public void BrickDestroyed(){
		if (Brick.breakableBricksInScene <= 1) {
			NextLevel();
		}
	}
}