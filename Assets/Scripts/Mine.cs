using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	float damage = 0.2f;

	void OnTriggerEnter(Collider other){

		if (!other.CompareTag ("Player")) {
			return;		
		}

		//Debug.Log ("BOUM!");
		other.rigidbody.AddForce (other.transform.forward * -400.0f);
		other.SendMessage ("Hit", damage, SendMessageOptions.DontRequireReceiver);
	}
}
