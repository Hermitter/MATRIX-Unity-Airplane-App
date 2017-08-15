using UnityEngine;
using System.Collections;

public class hitDetection : MonoBehaviour {
	Utility utility = new Utility();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Score.score != 0)//Do not include score after score wipe
			PlayerPrefs.SetInt ("lastScore", Score.score);//save player's last score
	}
	//trigger function
	void OnCollisionEnter (Collision col) {
		if(col.gameObject.name == "Rocket(Clone)")
		{
			Score.score = 0;
			utility.changeScene("gameMenu");
			AudioSource endSound = GameObject.Find("Utility").GetComponent<AudioSource>();
			endSound.Play();
		}
	}
}
