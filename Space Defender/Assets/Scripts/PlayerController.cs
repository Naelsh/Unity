using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 7f;

	private float padding = 0.6f;
	private float xMin, xMax, yMin, yMax;


	// Use this for initialization
	void Start () {
		// get the information from what is visible in the camera viewport
		float distance = transform.position.z - Camera.main.transform.position.z; // distance between the camera and the object (player in this case)

		// these vectors are relative to the viewport of the main camera (Camera.main) and the value is ia percentile of the view. So it ranges from 0 to 1.
		Vector3 leftMostPos = Camera.main.ViewportToWorldPoint (new Vector3 (0f,0f,distance));
		Vector3 rightMostPos = Camera.main.ViewportToWorldPoint (new Vector3 (1f,0f,distance));
		Vector3 bottomMostPos = Camera.main.ViewportToWorldPoint (new Vector3 (0f,1f,distance));
		Vector3 topMostPos = Camera.main.ViewportToWorldPoint (new Vector3 (0f,0f,distance));

		xMin = leftMostPos.x + padding;
		xMax = rightMostPos.x - padding;
		yMin = topMostPos.y + padding;
		yMax = bottomMostPos.y - padding;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 shipPos = new Vector3 (this.transform.position.x, this.transform.position.y, 0f);

		// increment or decrement based on key press.
		// Time.deltaTime is used in order to update based on time lapsed and not only frames passed.
		// horizontal movement
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			shipPos.x -= (speed * Time.deltaTime);
		}else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			shipPos.x += (speed * Time.deltaTime);
		}

		// vertical movement
		if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)) {
			shipPos.y += (speed * Time.deltaTime);
		}else if (Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow)) {
			shipPos.y -= (speed * Time.deltaTime);
		}

		// make sure the ship cant fly ofscreen
		shipPos.x = Mathf.Clamp (shipPos.x, xMin, xMax);
		shipPos.y = Mathf.Clamp (shipPos.y, yMin, yMax);

		this.transform.position = shipPos;
	}
}
