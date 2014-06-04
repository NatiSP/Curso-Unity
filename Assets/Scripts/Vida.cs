using UnityEngine;
using System.Collections;

public class Vida : MonoBehaviour {

	public float life = 5.0f;

	public void Hit(float receivedDamage){
		life = life - receivedDamage;
		if(life >= 0.0f)
			guiTexture.pixelInset = new Rect(guiTexture.pixelInset.x, guiTexture.pixelInset.y, 24 * life, guiTexture.pixelInset.height);
		else
			guiTexture.pixelInset = new Rect(guiTexture.pixelInset.x, guiTexture.pixelInset.y, 0, guiTexture.pixelInset.height);
	}

	public void Add(){
		life++;
		guiTexture.pixelInset = new Rect(guiTexture.pixelInset.x, guiTexture.pixelInset.y, 24 * life, guiTexture.pixelInset.height);
	}

	public void Set(float num){
		life = num;
		guiTexture.pixelInset = new Rect(guiTexture.pixelInset.x, guiTexture.pixelInset.y, 24 * life, guiTexture.pixelInset.height);
	}
	
}
