using UnityEngine;
using System.Collections;

public class Corazon : MonoBehaviour {

	public float rotacion = 200.0f;
	
	void OnTriggerEnter(Collider other){
		
		if (!other.CompareTag ("Player")) {
			return;		
		}
		
		//Debug.Log ("BOUM!");
		other.SendMessage ("AddLife");
		Destroy (this.gameObject);
	}
	
	void Update(){
		transform.Rotate(0, rotacion * Time.deltaTime, 0, Space.World);
	}
}
