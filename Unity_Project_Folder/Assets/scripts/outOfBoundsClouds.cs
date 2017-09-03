using UnityEngine;
using System.Collections;

public class outOfBoundsClouds : MonoBehaviour {
	GameObject player;
	GameObject spawner;
	// Use this for initialization
	void Start (){
		player = GameObject.Find("PlaneWhole");
		spawner = GameObject.Find("Debris");
	}

	// Update is called once per frame
	void Update () {
		//destory if to far from player or spawner
		if (transform.position.z < player.transform.position.z-700 || transform.position.z > spawner.transform.position.z+90f) {
			Destroy (this.gameObject);
		}

		if (transform.position.x < player.transform.position.x-700 || transform.position.x > player.transform.position.x+700) {
			Destroy (this.gameObject);
		}

		if (transform.position.y < player.transform.position.y-700 || transform.position.y > player.transform.position.y+700) {
			Destroy (this.gameObject);
		}
	}
}
