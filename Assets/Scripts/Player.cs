﻿ using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 0.1f;
	public GameObject ball;

	private float defalutSpeed;
	private float stoppedX = 0;
	private float moveDirection;
	// Use this for initialization
	void Start () {
		defalutSpeed = speed;

		CreateBall ();
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw ("Horizontal");
		Move (x);
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		if (layerName == "SideWall") {
			speed = 0;
//			stoppedX = Input.GetAxisRaw ("Horizontal");
			stoppedX = moveDirection;
		}
	}

	void OnTriggerStay2D(Collider2D c)
	{
	}

	void OnTriggerExit2D(Collider2D c)
	{
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		if (layerName == "SideWall") {
			stoppedX = 0;
		}
	}

	public void CreateBall()
	{
		Vector3 ballPos = new Vector3 (transform.position.x, (transform.position.y + 1.0f), transform.position.z);
		Instantiate (ball, ballPos, ball.transform.rotation);
	}

	// +1: right, -1:left
	public void Move(float xDirection)
	{
		moveDirection = xDirection;
		if (stoppedX == moveDirection) {
			return;
		}
		speed = defalutSpeed;
		transform.Translate(new Vector2(speed * xDirection  , 0));
	}
}
