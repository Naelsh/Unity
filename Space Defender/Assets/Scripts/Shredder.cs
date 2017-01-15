using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){ // the gameobject that enters
		Destroy (collider.gameObject); // is destroyed. GameObject needs 1. A rigidbody 2. A collider
	}
}
