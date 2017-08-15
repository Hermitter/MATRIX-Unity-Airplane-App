using UnityEngine;
using System.Collections;
using System;

public class Controller : MonoBehaviour {

    WebSocket w = new WebSocket(new Uri("ws://127.0.0.1:3000"));

    // Use this for initialization
    IEnumerator Start (){
        yield return StartCoroutine(w.Connect());
        w.SendString("Hi there");
        Debug.Log("Updated");
        int i = 0;
        while (true)
        {
            string reply = w.RecvString();
            if (reply != null)
            {
                Debug.Log("Received: " + reply);
                w.SendString("Hi there" + i++);
            }
            if (w.error != null)
            {
                Debug.LogError("Error: " + w.error);
                break;
            }
            yield return 0;
        }
    }
	



	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
            w.SendString("space key was pressed");
    }
}
