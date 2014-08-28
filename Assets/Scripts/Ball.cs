using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float speed = 5;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = Vector2.one.normalized * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		if (layerName == "SideWall") {
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x * -1, rigidbody2D.velocity.y).normalized * speed;
		}

		if (layerName == "TopWall" || layerName == "Player" || layerName == "Block") {
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y * -1).normalized * speed;
		}
	}
	
	void OnTriggerStay2D(Collider2D c)
	{
		//		Debug.Log ("player OnTriggerStay2D");
	}
	
	void OnTriggerExit2D(Collider2D c)
	{
//		Debug.Log ("player OnTriggerExit2D");
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		if (layerName == "GameArea") {
			Destroy(gameObject);
			CreateNewBall();
		}
	}

	private void CreateNewBall()
	{
		GameObject player = GameObject.Find("player");
		Player playerScript = (Player) player.GetComponent(typeof(Player));
		playerScript.CreateBall ();
	}

	private int RandomPlusMinus()
	{	
		float random = Random.value;
		if (random > 0.5) {
			return 1;
		} else {
			return -1;		
		}
	}
}
