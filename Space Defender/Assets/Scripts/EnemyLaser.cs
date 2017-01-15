using UnityEngine;
using System.Collections;

public class EnemyLaser : MonoBehaviour {
	
	public float speed = 5f;
	public float damage = 100f;
	
	// Use this for initialization
	void Awake () {
		
	}
	
	// a function for executing something when it hits something
	public void Hit (){
		Destroy (gameObject);
	}
	
	public float GetDamage(){
		return damage;
	}
	
	// Update is called once per frame
	void Update () {
		MoveMissile ();
	}
	
	void MoveMissile(){
		transform.position += Vector3.down * speed * Time.deltaTime;
	}
}
