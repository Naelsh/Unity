using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	public float width = 5f;
	public float height = 2f;
	public float speed = 4f;
	public float spawnDelay = 0.5f;

	private float xMin, xMax;
	private bool isMovingRight = true;

	// Use this for initialization
	void Start () {
		// create enemies at each spawnlocation
		CreateEnemy ();

		float distance = transform.position.z - Camera.main.transform.position.z; // distance between the camera and the object (player in this case)

		// get the information about the camera
		Vector3 leftMostPos = Camera.main.ViewportToWorldPoint (new Vector3 (0f,0f,distance));
		Vector3 rightMostPos = Camera.main.ViewportToWorldPoint (new Vector3 (1f,0f,distance));

		xMin = leftMostPos.x;
		xMax = rightMostPos.x;

	}

	
	// Update is called once per frame
	void Update () {

		if (isMovingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		float leftMostOfFormation = transform.position.x - (0.5f * width);
		if (rightEdgeOfFormation > xMax) {
			isMovingRight = false;
		}else if (leftMostOfFormation < xMin) {
			isMovingRight = true;
		}

		if (AllMembersDead()) {
			SpawnEnemyUntilFull();
		}
	
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position,new Vector3(width,height,0f));
	}

	void CreateEnemy(){
		foreach (Transform child in transform) {
			GameObject newEnemy = Instantiate (enemy, child.position, Quaternion.identity) as GameObject;
			newEnemy.transform.parent = child; // creates the GameObject as an object underneath the parentobject. Thus making it neat in the Hierarchy-view (and spawn at correct place)
		}

	}

	void SpawnEnemyUntilFull(){
		Transform nextFreePosition = NextFreePosition ();
		if (nextFreePosition) {
			GameObject newEnemy = Instantiate (enemy, nextFreePosition.position, Quaternion.identity) as GameObject;
			newEnemy.transform.parent = nextFreePosition;
		}
		if (NextFreePosition()) {
			Invoke ("SpawnEnemyUntilFull", spawnDelay);
		}
	}

	// cycles thrugh each position in the hierarchy. For each spawnlocation (child) in the EnemySpawner it will return false if there is an enemy present (grandchild)
	// if there are no grandchildren, it returns true, that is "All Members are Dead"
	bool AllMembersDead(){
		foreach (Transform child in transform) {
			if (child.childCount > 0) {
				return false;
			}
		}
		return true;

	}

	// This function searches the positions for the next empty position. Empty in this regard is if there is no enemy ship present
	Transform NextFreePosition(){
		foreach (Transform child in transform) {
			if (child.childCount == 0) {
				return child;
			}
		}
		return null;
	}
}
