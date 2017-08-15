using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class showLastScore : MonoBehaviour {
	//initial variables
	Text lastScoreUpdate;

	// Use this for initialization
	void Start () {
		lastScoreUpdate = gameObject.GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		lastScoreUpdate.text = "Last-Score: " + PlayerPrefs.GetInt("lastScore");
	}
}
