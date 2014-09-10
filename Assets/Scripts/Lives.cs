using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SetText(FindObjectOfType<Manager>().Lives);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetText(int lives)
	{
		guiText.text = lives.ToString();
	}
}
