using UnityEngine;
using System.Collections;

public class outOfBounds : MonoBehaviour {
	public GameObject target;
	public GameObject spawner;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//rotate gameObject
		transform.Rotate(Vector3.forward * Time.deltaTime*300);
		//move towards player after a little distance
		if (transform.position.z < spawner.transform.position.z)
			transform.position += Vector3.forward * Time.deltaTime * -300;//orig 100
		//destory if to far from player or spawner
		if (transform.position.z < target.transform.position.z-50f || transform.position.z > spawner.transform.position.z+90f) {
			Destroy (this.gameObject);
		}
	}
}
