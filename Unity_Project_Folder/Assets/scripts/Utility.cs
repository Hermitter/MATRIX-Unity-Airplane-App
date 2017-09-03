using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Utility : MonoBehaviour {

    string serverIP = "";

    public void setIP()
    {
        GameObject inputBar = GameObject.Find("InputField");
        InputField inputValue = inputBar.GetComponent<InputField>();
        serverIP = inputValue.text;
		PlayerPrefs.SetString ("ServerIP", serverIP);//save ip info for next session
        Debug.Log(serverIP);
    }

    public string getIP() {
        return serverIP;
    }


    public void changeScene(string newScene){
		DontDestroyOnLoad (GameObject.Find ("Utility"));
		SceneManager.LoadScene (newScene);
	}


	//Start button sound
	public void playStartSound(){
		AudioSource startSound = GameObject.Find("startSound").GetComponent<AudioSource>();
		startSound.Play();

		StartCoroutine(waitForStartSound((int)startSound.clip.length));
	}
	IEnumerator waitForStartSound(int length){
		yield return new WaitForSeconds(length);
		changeScene("gameTesting");
	}
}
