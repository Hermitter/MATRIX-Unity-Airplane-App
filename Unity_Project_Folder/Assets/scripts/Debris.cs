using UnityEngine;
using System.Collections;

public class Debris : MonoBehaviour {
	float spawnRange = 340f;//spawn box
	int initialSpawnAmount = 50;//amount of initial missles
	int spawnAmount;
	public GameObject obstacle;
	public GameObject anchorTarget;
	// Use this for initialization
	void Start () {
		//set interval
		InvokeRepeating("SpawnMissile", 0, 1);
		InvokeRepeating("idleMissile",0,15);
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnAmount < 180)
			spawnAmount = initialSpawnAmount+Score.score/2;//********
		//slowly rotate spawner
		transform.Rotate(Vector3.up * Time.deltaTime*20);
		//spawner will follow player on x y z
		transform.position = new Vector3(anchorTarget.transform.position.x, anchorTarget.transform.position.y, anchorTarget.transform.position.z+800);//orig 500
	}

	/////////////////////////
	// FUNCTIONS
	///////////////////////
	// void idleMissile(){
	// 		//missile to kill player if they are no moving
	// 	Instantiate(obstacle,//copied object
	// 		new Vector3(transform.position.x,
	// 			transform.position.y,
	// 			transform.position.z-15),//z
	// 		obstacle.transform.rotation);//rotation
	// }


	void SpawnMissile(){
		for (int i = 0; i < spawnAmount; i++)//amount of times spawned
			Instantiate(obstacle,//copied object
					new Vector3(Random.Range(transform.position.x-spawnRange, transform.position.x+spawnRange),//x
					Random.Range(transform.position.y-spawnRange, transform.position.y+spawnRange),//y
					transform.position.z-10),//z
					obstacle.transform.rotation);//rotation
	}
}