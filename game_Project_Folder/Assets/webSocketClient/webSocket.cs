using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;//****

public class webSocket : MonoBehaviour
{
    //INITIAL
    Utility utility;//get class functions
    public static float yaw = 0;
    public static float pitch = 0;
    public static float roll = 0;

    WebSocket w;
//AWAKE
    void Awake() {
        utility = FindObjectOfType(typeof(Utility)) as Utility;
    }
//START
    IEnumerator Start() {
        w = new WebSocket(new Uri("ws://"+utility.getIP()));//point to server ip

        yield return StartCoroutine(w.Connect());
        w.SendString("Ready");//ready for first data
        while (true)
        {
            string reply = w.RecvString();
            if (reply != null)
            {
                string[] splitData = reply.Split(new string[] { "/" }, StringSplitOptions.None);//yaw[0]/pitch[1]/roll[2]
                yaw = float.Parse(splitData[0]);
				pitch = float.Parse(splitData[1]);
				roll = float.Parse(splitData[2]);

                w.SendString("Ready");//ready for next data
                //Debug.Log("Received: " + reply);
            }
            if (w.error != null)
            {
                Debug.LogError("Error: " + w.error);
                break;
            }
            yield return 0;
        }
    }
//UPDATE
    void Update()
    {

    }

}
