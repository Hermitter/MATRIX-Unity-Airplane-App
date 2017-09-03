using UnityEngine;
using System.Collections;

public class planeEngine : MonoBehaviour {
	float startingPitch = 1;
	AudioSource engineSound;
	// Use this for initialization
	void Start () {
		engineSound = GetComponent<AudioSource>();
		engineSound.pitch = startingPitch;

	}
	
	// Update is called once per frame
	void Update () {
		engineSound.pitch = startingPitch;
		startingPitch = transform.rotation.x*0.4f+transform.rotation.z*0.4f+1;
	}
}
