using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	void OnDrawGizmos(){
		Gizmos.DrawWireSphere (transform.position,1f);
	}
}
