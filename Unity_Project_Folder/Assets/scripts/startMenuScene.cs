using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class startMenuScene : MonoBehaviour {
	public GameObject axis;
	public GameObject target;
	public GameObject button;

	// Use this for initialization
	void Start () {
		GameObject inputBar = GameObject.Find("InputField");
		InputField inputValue = inputBar.GetComponent<InputField>();
		inputValue.text = PlayerPrefs.GetString ("ServerIP");
	}
	
	// Update is called once per frame
	void Update () {
		//camera rotation around plane
		axis.transform.Rotate(Vector3.up * Time.deltaTime*20);
		transform.LookAt(target.transform);
		//connect to server on enter/return key (shortcut)
		if (Input.GetKeyDown("return") || Input.GetKeyDown("enter"))
		{
			//press server connect button
			ExecuteEvents.Execute(button.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
		}
	}

	//save ip data for next playthrough
	public void saveIP() {
		PlayerPrefs.SetString ("ServerIP", "12");
	}
}
