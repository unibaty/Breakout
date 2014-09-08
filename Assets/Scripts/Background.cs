using UnityEngine;
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

		FindObjectOfType<Player> ().Move (direction);
	}
}
