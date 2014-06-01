using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {

	float lifeTime = 1.5f;

	void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("Enemy")){
			Destroy (other.gameObject);
			AutoDestruct();
		}
	}

	void Update(){

		lifeTime -= Time.deltaTime;
		if (lifeTime <= 0)
			AutoDestruct();
	}

	void AutoDestruct(){
		Destroy (gameObject);
	}
}
