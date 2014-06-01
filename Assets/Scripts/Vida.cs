using UnityEngine;
using System.Collections;

public class Vida : MonoBehaviour {

	public float life = 3.0f;

	public void Hit(){
		life--;
		transform.localScale = new Vector3(0.5f * life, transform.localScale.y, transform.localScale.z);
	}

	public void Add(){
		life++;
		transform.localScale = new Vector3(0.5f * life, transform.localScale.y, transform.localScale.z);
	}
}
