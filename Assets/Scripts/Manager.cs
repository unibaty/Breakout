using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
	public GameObject player;
	private GameObject title;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Return))
		{
			Debug.Log("Return!");
			FindObjectOfType<Player> ().CreateBall();
		}
	}

	void GameStart ()
	{

	}

	void GameOver ()
	{

	}
}
