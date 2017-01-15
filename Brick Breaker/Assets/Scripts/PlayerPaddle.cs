using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour {

	public bool autoPlay = false;

	private Ball ball;

	void Start (){
		ball = GameObject.FindObjectOfType<Ball> ();
	}

	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutomaticMove();
		}

	}

	void MoveWithMouse(){
		// Input.mousePosition gets the coordinates for the mouse. Adding the "/ Screen.width" makes it possible to have the mosition relative to the screen width
		// by multiplying with 16 we get the number in blocks.
		float currentMousePositionInBlocks = Input.mousePosition.x / Screen.width * 24;
		
		// transform needs a vector3 in order to work.
		Vector3 paddlePos = new Vector3 (this.transform.position.x,this.transform.position.y,0f);
		paddlePos.x = Mathf.Clamp (currentMousePositionInBlocks, 2.9f, 23.1f);
		
		this.transform.position = paddlePos;
	}

	void AutomaticMove(){
		float ballLocationX = ball.transform.position.x;
		Vector3 paddlePos = new Vector3 (this.transform.position.x,this.transform.position.y,0f);
		paddlePos.x = Mathf.Clamp (ballLocationX, 2.9f, 23.1f);
		
		this.transform.position = paddlePos;

	}
}
