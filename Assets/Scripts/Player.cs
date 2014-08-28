 using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 0.1f;
	public GameObject ball;

	private float defalutSpeed;
	private float stoppedX = 0;

	// Use this for initialization
	void Start () {
		defalutSpeed = speed;

		CreateBall ();
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw ("Horizontal");
		if (stoppedX == x) {
			return;
		}
		speed = defalutSpeed;
		transform.Translate(new Vector2(speed * x  , 0));
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
//		Debug.Log ("Player layerName:"+layerName);
		if (layerName == "SideWall") {
			speed = 0;
			stoppedX = Input.GetAxisRaw ("Horizontal");
		}
	}

	void OnTriggerStay2D(Collider2D c)
	{
//		Debug.Log ("player OnTriggerStay2D");
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
}
