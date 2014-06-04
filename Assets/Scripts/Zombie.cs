using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	Transform target;
	public float forwardForce = 50.0f;
	public float sightRange = 15.0f;
	public float maxVelocity = 1.0f;
	public float damage = 0.3f;
	int recorrido = 0;
	float randX;
	float randZ;

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Find ("Player");
		target = go.transform;
		randX = (Random.value - 0.5f);
		randZ = (Random.value - 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		HuntTarget ();
	}

	void HuntTarget(){
		Vector3 towardsTarget = (target.position - transform.position);


		if (towardsTarget.magnitude < sightRange)
			rigidbody.AddForce (towardsTarget.normalized * forwardForce * Time.deltaTime);
		else {
			if(recorrido > 500){
				randX = (Random.value - 0.5f);
				randZ = (Random.value - 0.5f);
				recorrido = 0;
			}
			rigidbody.AddForce (new Vector3 (randX, 0, randZ).normalized * forwardForce * Time.deltaTime);
			recorrido++;
		}
		//Debug.Log (rigidbody.velocity.magnitude);

		rigidbody.velocity = Vector3.ClampMagnitude (rigidbody.velocity, maxVelocity);
	}

	void OnCollisionEnter(Collision other){
		
		if (other.gameObject.tag != "Player") {
			return;		
		}
		
		//Debug.Log ("BOUM!");
		other.rigidbody.AddForce ((other.transform.position - transform.position).normalized * 100.0f);
		other.gameObject.SendMessage ("Hit", damage, SendMessageOptions.DontRequireReceiver);
	}
}
