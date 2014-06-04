using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {
	
	public int coins = 0;
	

	public void Death(){
		coins = 0;
		guiText.text = coins.ToString ();
	}
	
	public void Add(){
		coins++;
		guiText.text = coins.ToString ();
	}
	
}
