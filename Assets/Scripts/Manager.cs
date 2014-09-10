using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
//	public GameObject player;
	GameObject title;
	enum Scenes {Playing, Title};
	int scene = (int)Scenes.Title;
	int score = 0;

	public int DefaultLives = 3;
	public int Lives;
	// Use this for initialization
	void Start () {
		title = GameObject.Find ("Title");
		Lives = DefaultLives;
		FindObjectOfType<Lives>().SetText(Lives);
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

	public void LivesDown()
	{
		if(Lives <= 0){
			return;
		}
		Lives --;
		FindObjectOfType<Lives>().SetText(Lives);
	}

	public void ResetLives()
	{
		Lives = DefaultLives;
	}
}
