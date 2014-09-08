using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Show () {
		gameObject.SetActive(true);
		Debug.Log("Show!");
	}

	public void Hide () {
		gameObject.SetActive(false);
		Debug.Log("Hide!");
	}
}
