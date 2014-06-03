using UnityEngine;
using System.Collections;

public class CreatureSpawner : MonoBehaviour {

	public GameObject creaturePrefab;
	public float creationRate = 5.0f;

	public int maxCreatureCount = 3;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnCreature", creationRate, creationRate);
	}

	void SpawnCreature(){
		GameObject []go = GameObject.FindGameObjectsWithTag("Enemy");

		if (go.Length < maxCreatureCount) {
			Instantiate (creaturePrefab, transform.position, Quaternion.identity);
		}
	}

}
