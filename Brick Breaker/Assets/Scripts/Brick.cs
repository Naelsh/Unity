using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public int maxHits;
	public static int breakableBricksInScene = 0;
	public GameObject smoke;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;



	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableBricksInScene++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		SetColorBasedOnHitsLeft(maxHits);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collider){
		if (isBreakable) {
			HandleHits();
		}
		// AudioSource is currently set to volume 0 since anoying sound :D
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.0f); // creates an audioobject where the brick was if we want it to have a sound even after the brick is destroyed
	}

	void HandleHits(){
		timesHit++;
		if (timesHit >= maxHits) {
			// SimulateWin ();
			breakableBricksInScene--;
			levelManager.BrickDestroyed();

			// creates the smoke in the scene. INSTANTIATE = create new instance
			// "as GameObject" casts the object to GameObject
			GameObject newSmoke = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
			newSmoke.particleSystem.startColor = this.GetComponent<SpriteRenderer>().color;
			Destroy (gameObject);
		} else {
			SetColorBasedOnHitsLeft (maxHits - timesHit);
		}
	}

	void SetColorBasedOnHitsLeft(int timesLeftUntilDeath){

		switch (timesLeftUntilDeath){
		case 0:
			GetComponent<SpriteRenderer>().color = Color.grey;
			break;
		case 1:
			GetComponent<SpriteRenderer> ().color = Color.magenta;
			break;
		case 2:
			GetComponent<SpriteRenderer> ().color = Color.cyan;
			break;
		case 3:
			GetComponent<SpriteRenderer> ().color = Color.green;
			break;
		default:
			break;
		}
	}

}
