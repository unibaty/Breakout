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

	public IEnumerator RoutineMethod;

	public GameObject Stage;

	//

	
	// Use this for initialization
	void Start () {
		title = GameObject.Find ("Title");
		Lives = DefaultLives;
		var label_Lives = FindObjectOfType<Lives>();
		Debug.Log(label_Lives);
		label_Lives.SetText(Lives);

		//set routin method..
		RoutineMethod = RoutineEvents();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Return))
		{
			GameStart();

			//set routin method..
			RoutineMethod = RoutineEvents();
			//start coroutine
			StartCoroutine (RoutineMethod);

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

	IEnumerator RoutineEvents()
	{
		while (true){
			yield return new WaitForSeconds (5.0f);
			Debug.Log ("routine Event");

			Stage.GetComponent<Stage>().StageRoutinMethod();
		}
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

	public void MethodsOnBallIsDead(){
		Debug.Log ("CALL MethodsOnBallIsDead");
		LivesDown();
		StopCoroutine (RoutineMethod);

		// ball_track all remove
		FindObjectOfType<BallTrack>().DestroyOwn();
	}

	public void ResetLives()
	{
		Lives = DefaultLives;
	}
}
