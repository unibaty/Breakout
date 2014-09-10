using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		guiText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetScore(int newScore)
	{
		guiText.text = newScore.ToString();
	}
}
