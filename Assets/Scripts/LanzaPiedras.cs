using UnityEngine;
using System.Collections;

public class LanzaPiedras : MonoBehaviour {

	public float lauchForce = 200;
	public GameObject ammoPrefab;

	public void Attack(){
		GameObject go = GameObject.Instantiate (
			ammoPrefab,
			transform.position,
			Quaternion.identity) as GameObject;
		go.rigidbody.AddForce (transform.forward * lauchForce);
	}
}
