using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int ScoreValue;
	private GameController gamecontroller;
	void Start()

	{
		GameObject gamecontrollerObject = GameObject.FindWithTag ("GameController");
		if (gamecontrollerObject != null)
		{
			gamecontroller = gamecontrollerObject.GetComponent <GameController> ();


		}
		if (gamecontroller == null)
		{
			Debug.Log ("CAN NOT FIND (GameController) SCRIPT");
		}


	}


	void OnTriggerEnter (Collider other)
	{
		//tr = GetComponent<Rigidbody> ();

		if (other.tag == "Boundry")
		{
			return;
		}
		if (other.tag == "Bolt") 
		{

	
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
			gamecontroller.AddScore (ScoreValue);
		}
		if (other.tag == "Player") 
			{
			
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
			gamecontroller.GameOver ();
			}
		}

}
