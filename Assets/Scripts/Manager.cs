using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
//	public GameObject player;
	private GameObject title;
	enum Scenes {Playing, Title};
	private int scene = (int)Scenes.Title;
	private int score = 0;

	// Use this for initialization
	void Start () {
		title = GameObject.Find ("Title");
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Return))
		{
			GameStart();
		}
	}

	public void GameStart ()
	{
		int t = (int)Scenes.Title;
		if(scene != t){
			return;
		}
		scene = (int)Scenes.Playing;
		FindObjectOfType<Player> ().CreateBall();
		HideTitle();

	}

	public void GameOver ()
	{
		ShowTitle();
		scene = (int)Scenes.Title;
	}

	void ShowTitle()
	{
		title.SetActive(true);
	}

	void HideTitle()
	{
		title.SetActive(false);
	}

	public void ScoreUp()
	{
		score ++;
		FindObjectOfType<Score> ().SetScore(score);
	}
}
