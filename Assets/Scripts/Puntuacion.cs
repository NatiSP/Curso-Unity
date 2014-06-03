using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {
	
	public int coins = 0;
	

	public void Death(){
		coins = 0;
	}
	
	public void Add(){
		coins++;
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 10, 150, 150), coins.ToString());
	}
}
