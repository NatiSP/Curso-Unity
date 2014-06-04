using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float jumpForce = 100.0f;
	public float forwardForce = 100.0f;
	public float jumpForwardForce = 100.0f;
	public float torque = 5.0f;
	public int jumpCount = 3;
	public float lives = 5.0f;
	public int coins = 0;

	bool isGrounded = true;
	bool keysEnabled = true;
	Vector3 pointA;

	ParticleSystem blood;
	Transform weapon;
	public GUITexture life;
	//GUIText ncoins;

	// Use this for initialization
	void Start () {
		pointA = transform.position;
		Transform t = transform.FindChild ("Blood");
		blood = t.particleSystem;

		weapon = transform.FindChild ("Weapon");
	}

	// Update is called once per frame
	void Update () {
		if ((Input.GetMouseButtonDown(0))) {
			//Debug.Log ("Espacio!");
			//rigidbody.AddForce(Vector3.up * jumpForce);
			Attack();
		}

		if (Input.GetKeyDown (KeyCode.Space) && (jumpCount > 0)) {
			rigidbody.AddForce(Vector3.up * jumpForce);
			jumpCount--;
			isGrounded = false;
		}

		if (Input.GetKey (KeyCode.W) && keysEnabled == true){
			if(isGrounded == true)
				rigidbody.AddForce (transform.forward * forwardForce * Time.deltaTime);
			else
				rigidbody.AddForce (transform.forward * jumpForwardForce * Time.deltaTime);
		}


		if (Input.GetKey (KeyCode.S) && keysEnabled == true){
			if(isGrounded == true)
				rigidbody.AddForce (transform.forward * -(forwardForce) * Time.deltaTime);
			else
				rigidbody.AddForce (transform.forward * -jumpForwardForce * Time.deltaTime);
		}

		if((Input.GetAxis("Mouse X")<0) && keysEnabled == true){
			//Code for action on mouse moving left
			//rigidbody.AddTorque (transform.up * -torque * Time.deltaTime);
			//print("Mouse moved left");
			transform.Rotate(Vector3.up * -torque);
		}

		if((Input.GetAxis("Mouse X")>0) && keysEnabled == true){
			//Code for action on mouse moving right
			//rigidbody.AddTorque (transform.up * torque * Time.deltaTime);
			//print("Mouse moved left");
			transform.Rotate(Vector3.up * torque);
		}

		if (Input.GetKey (KeyCode.D) && keysEnabled == true){
			if(isGrounded == true)
				rigidbody.AddForce (transform.right * forwardForce * Time.deltaTime);
			else
				rigidbody.AddForce (transform.right * jumpForwardForce * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.A) && keysEnabled == true){
			if(isGrounded == true)
				rigidbody.AddForce (transform.right * -forwardForce * Time.deltaTime);
			else
				rigidbody.AddForce (transform.right * -jumpForwardForce * Time.deltaTime);
		}

		if ((jumpCount < 3) && (isGrounded == true)) {
			jumpCount = 3;	
			//Debug.Log ("Salto = " + jumpTime);
		}

		if (lives <= 0) {
			Death ();
			//ncoins.SendMessage ("Death");
		}

		if (transform.position.y < -10) {
			Death ();		
		}
	}

	void OnCollisionEnter (Collision hit)
	{

		isGrounded = true;
		// check message upon collition for functionality working of code.
		//Debug.Log ("I am colliding with something");
	}

	public void Hit(float receivedDamage){

		Debug.Log ("Ay!");
		blood.Play ();
		lives = lives - receivedDamage;
		life.SendMessage ("Hit", receivedDamage);
	}

	public void AddCoin(){
		coins++;
	}

	public void AddLife(){
		lives++;
		life.SendMessage ("Add");
	}

	void Attack(){
		weapon.SendMessage ("Attack");
	}

	void Death(){
		rigidbody.position = pointA;
		lives = 5;
		
		life.SendMessage ("Set", 5.0f);
	}

	IEnumerator StartWait()
	{
		yield return StartCoroutine(Wait());
	}
	
	IEnumerator Wait()
	{
		Debug.Log("waiting");
		yield return new WaitForSeconds(1);      
	}

}