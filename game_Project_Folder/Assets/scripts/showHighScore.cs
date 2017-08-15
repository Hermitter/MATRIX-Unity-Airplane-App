using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class showHighScore : MonoBehaviour {
	//initial variables
	Text highScoreUpdate;

	// Use this for initialization
	void Start () {
		highScoreUpdate = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		highScoreUpdate.text = "HighScore: " + PlayerPrefs.GetInt("highScore");
	}
}
