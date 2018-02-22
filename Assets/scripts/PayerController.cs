using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundry

{
	public float xMin,xMax,zMin,zMax;

}

public class PayerController : MonoBehaviour {
	private Rigidbody rb;


	public float speed;
	public float tilt;
	public Boundry boandry;
	public GameObject shot;
	public Transform shothit;
	public float fireRate;
	public float nextFire;
	//public AudioClip SoundToPlay;
	//public int volume;
	private AudioSource Audio;

	void Update()
	{
		
		Audio = GetComponent<AudioSource> ();
		if (Input.GetButton ("Fire") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shothit.position, shothit.rotation);
		
			Audio.Play ();

		}
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		rb = GetComponent<Rigidbody> ();
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");


		Vector3 movement = new Vector3 (moveHorizontal,0.0f, moveVertical);
		rb.velocity = movement * speed;
		rb.position = new Vector3 (
			Mathf.Clamp  (rb.position.x, boandry.xMin, boandry.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boandry.zMin,boandry.zMax)
			);

		rb.rotation = Quaternion.Euler (0.0f,0.0f,rb.velocity.x * -tilt);


	}
}
