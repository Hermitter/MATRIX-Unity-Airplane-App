using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Score : MonoBehaviour {
	///////////////////////
	//INITIAL VARIABLES
	/////////////////////
	//FPS Controller
	public GameObject player;
	//distance needed to increase score
	public double distanceToBeat = 35;
	public static int score = 0;
	//UI Text Element
	Text scoreUpdate;

	///////////////////////
	//FUNCTIONS
	/////////////////////
	void Start () {
		if (!PlayerPrefs.HasKey("highScore")) {
			PlayerPrefs.SetInt ("highScore", 0);
		}

		if (!PlayerPrefs.HasKey("lastScore")) {
			PlayerPrefs.SetInt ("lastScore", 0);
		}

		scoreUpdate = gameObject.GetComponent<Text>(); 
	}

	// Update is called once per frame
	void Update () {
		//if player moves forward
		if( player.transform.position.z > distanceToBeat){
			//update score
			score++;
			scoreUpdate.text = "Score: "+score;
			//update distance for next score
			distanceToBeat = player.transform.position.z+50;
			//update highScore
			if( score > PlayerPrefs.GetInt("highScore") )
				PlayerPrefs.SetInt ("highScore", score);
		}
		//if player moves backward
		else if( player.transform.position.z < distanceToBeat-100){
			//update score
			if (score != 0)
				score--;
			scoreUpdate.text = "Score: "+score;
			//update distance for next score
			distanceToBeat = player.transform.position.z+50;
		}
		print("Player Pos: "+player.transform.position.z);
		print("distanceToBeat: "+distanceToBeat);
	}
}
