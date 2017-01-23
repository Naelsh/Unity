using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

	public float hitPoints = 150f;
	public EnemyLaser laserShot;
	public float shootingFrequency = 0.5f;
	public int pointValue = 123;
	public AudioSource laserAudio;

	private ScoreKeeper scoreKeeper;

	void OnTriggerEnter2D(Collider2D collider){
		PlayerLaser playerLaser = collider.gameObject.GetComponent<PlayerLaser> ();
		if (playerLaser) {
			hitPoints -= playerLaser.GetDamage();
			playerLaser.Hit();
			if (hitPoints <= 0) {
				Destroy(gameObject);
				scoreKeeper.Score(pointValue);
			}
		}
	}

	void FireProjectile(){
		Instantiate(laserShot, new Vector3(this.transform.position.x,this.transform.position.y - 1f,this.transform.position.z), Quaternion.identity);
		laserAudio = GetComponent<AudioSource> ();
		laserAudio.Play ();
	}

	void Update(){

		float probability = shootingFrequency * Time.deltaTime;
		if (Random.value < probability){
			FireProjectile();
		}
	}

	void Start(){
		scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper>();
	}
}
