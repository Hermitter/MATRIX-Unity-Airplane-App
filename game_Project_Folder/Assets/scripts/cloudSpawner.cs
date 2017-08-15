using UnityEngine;
using System.Collections;

public class cloudSpawner : MonoBehaviour {
	//initial vars
	float spawnRange = 200f;//spawn box
	int spawnAmount = 4;//amount of missles
	float distanceToPass = 200;
	//cloud prefabs
	public GameObject cloudCumulus;
	//player
	public GameObject player;
	float playerX;
	float playerY;
	float playerZ;
	//cloud spawn timing
	float passX = 100;
	float passY = 100;
	float passZ = 100;
	// Use this for initialization
	void Start () {
		spawnCloudsZ (1);
	}
	
	// Update is called once per frame
	void Update () {
		//player pos
		playerX = player.transform.position.x;
		playerY = player.transform.position.y;
		playerZ = player.transform.position.z;
		//spawn clouds
		//Forward
		if (playerZ > passZ+200) {
			passZ = playerZ+distanceToPass;
			spawnCloudsZ (1);
		}
		//Backward
		else if (playerZ < passZ+300 * -1) {
			passZ = playerZ-distanceToPass;
			spawnCloudsZ (-1);
		}
		//right
		if (playerX > passX) {
			passX = playerX+distanceToPass;
			spawnCloudsX (1);
		}
		//Left
		else if (playerX < passX+350 * -1) {
			passX = playerX-distanceToPass;
			spawnCloudsX (-1);
		}
		//Up
		if (playerY > passY) {
			passY = playerY+distanceToPass;
			spawnCloudsY (1);
		}
		//Down
		else if (playerY < passY+300 * -1) {
			passY = playerY-distanceToPass;
			spawnCloudsY (-1);
		}
	}

	public void spawnCloudsY(float direction){
		GameObject cloud = (GameObject)Instantiate(cloudCumulus);
		//spawn clouds
		for (int i = 0; i < spawnAmount; i++)//amount of times spawned
			Instantiate(cloud,//copied object
				new Vector3(Random.Range(playerX-spawnRange, playerX+spawnRange),//x
					Random.Range(playerY+400*direction, playerY+700*direction),//y//700
					Random.Range(playerZ+350,playerZ+100)//z
				),cloud.transform.rotation);//rotation
	}

	public void spawnCloudsX(float direction){
		GameObject cloud = (GameObject)Instantiate(cloudCumulus);
		//spawn clouds
		for (int i = 0; i < spawnAmount; i++)//amount of times spawned
			Instantiate(cloud,//copied object
				new Vector3(Random.Range(playerX+550*direction, playerX+850*direction),//x//650
					Random.Range(playerY-spawnRange, playerY+spawnRange),//y
					Random.Range(playerZ+250,playerZ+150)//z
				),cloud.transform.rotation);//rotation
	}

	public void spawnCloudsZ(float direction){
		GameObject cloud = (GameObject)Instantiate(cloudCumulus);
		//spawn clouds
		for (int i = 0; i < spawnAmount; i++)//amount of times spawned
			Instantiate(cloud,//copied object
				new Vector3(Random.Range(playerX-spawnRange, playerX+spawnRange),//x
					Random.Range(playerY-spawnRange, playerY+spawnRange),//y
					Random.Range(playerZ+800*direction,playerZ+900*direction)//z
				),cloud.transform.rotation);//rotation
	}
}
