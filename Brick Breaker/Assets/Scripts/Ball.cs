using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private PlayerPaddle paddle; // in order to get the reference from the paddle object in the scene
	private Vector3 paddleToBallVector; // in order to get the 
	private bool isFired = false;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<PlayerPaddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position; // takes the three coordinatevalues of each object and subtract on from the other. This leaves us with the vale between
		
	}

	// Update is called once per frame
	void Update () {
		if (!isFired) {
			// lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// wait for a mouse press to launch
			if (Input.GetMouseButton(0)) {
				isFired = true;
				// initial launch
				this.rigidbody2D.velocity = new Vector2 (2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collider){
		Vector2 tweakDirection = new Vector2 (Random.Range(0f,0.2f),Random.Range(0f,0.2f));

		if (isFired) {
			audio.Play (); // this is currently muted
			rigidbody2D.velocity += tweakDirection;
		}
	}
}
