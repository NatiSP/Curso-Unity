using UnityEngine;
using System.Collections;

public class GameFinished : MonoBehaviour {

	public GUIText texto;

	void OnTriggerEnter (Collider other) {
		
		texto.enabled = true;
		
	}

}
