using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {
    public GameObject target;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (target.transform.position.x,target.transform.position.y+10,target.transform.position.z-50f);
        transform.LookAt(target.transform);
    }
}
