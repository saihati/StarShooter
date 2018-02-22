using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject Hazerd;
	public Vector3 spawnValue;
	public int HazerdCount;
	public float spawnWait;
	public float StartWait;
	public float WaveWait;
	public GUIText ScoreText;
	public int Score;
	public GUIText restartText;
	public GUIText GAmeOverText;
	public GUIText Times;

	private bool gameover;
	private bool restart;
	private float Timer;

	/// <summary>
	///test 
	public int ToRand;
	/// </summary>





	void Start()
	{
		gameover = false;
		restart = false;
		restartText.text =  "";
		GAmeOverText.text = "";
		//////////
		//ToRand = Random.Range (1, 100);
		//ToRand = 0;
		//Rindomize ();

		Score =  0;
		chose ();
		UpdateScore ();
		Timer = 0;

		StartCoroutine (SpawnWaves ());
	


		//StartCoroutine(SpawnWaves());
	}


	void Update()
	{
		Timer += Time.deltaTime;
		Times.text = Timer.ToString ();
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				Application.LoadLevel (Application.loadedLevel);
			}

		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (StartWait);
		while(true)
		{
			for(int i= 0; i < HazerdCount; i++)
			{
				
			Vector3 SpawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x),spawnValue.y,spawnValue.z);
			Quaternion spawnRotation = Quaternion.identity;

			Instantiate (Hazerd, SpawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
				
			}
			//UpdateScore ();
			//if (Score > 300 && Timer <= 20.0f) 
			//{
			//	return;
			//}
			if (Score > 300 && Timer > 30.0f)
			{
				spawnWait = 0.2f;
				HazerdCount = 50;

			}
			yield return new WaitForSeconds (WaveWait);
			if (gameover) 
			{
				restartText.text = "Press 'R' to restart";
				Timer = Time.fixedTime;
				Times.text = Timer.ToString ();

				restart = true;



				break;
			}
		}
	}

	void chose()
	{
		//ToRand = Random.Range(0,100);
	
	}

	public int Rindomize()
	{

		ToRand = Random.Range(0,100);
		return ToRand;
	}
	/*
	IEnumerator AnOtherWave()
	{
		yield return new WaitForSeconds (StartWait);
		while(true)
		{
			for(int i= 0; i < HazerdCount; i++)
			{
				for (int g = 0; g < 3; g++) 
				{
					
					Vector3 SpawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
					Quaternion spawnRotation = Quaternion.identity;

					Instantiate (Hazerd, SpawnPosition, spawnRotation);
					yield return new WaitForSeconds (spawnWait);
				}
			}
			yield return new WaitForSeconds (WaveWait);
			if (gameover) 
			{
				restartText.text = "Press 'R' to restart";
				restart = true;
				break;
			}
		}
	}
	*/
	public void AddScore (int newScore)
	{
		Score += newScore;
		UpdateScore ();

	}

	void UpdateScore()
	{
		//Score = Score + 1;
		ScoreText.text = "Score: " + Score;
	}
	public void GameOver()

	{
		GAmeOverText.text = " Game Over!";
			gameover = true;
			
	}
}
