﻿using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
//	public bool touchState = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < Input.touchCount; i++) {
			Touch touch = Input.GetTouch(i);
			Debug.Log("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
			Debug.Log("touch.position.x:" + touch.position.x);
			Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved){
				MovePlayer(touch.position.x);
			}

		}
	}

	private void MovePlayer(float touchX)
	{
		int direction; // 1 or -1
		if (touchX < (Screen.width / 2)) {
			direction = -1; // left
		} else {
			direction = 1; // right
		}

		GameObject player = GameObject.Find("player");
		Player playerScript = (Player) player.GetComponent(typeof(Player));
		playerScript.Move(direction);
	}
}
