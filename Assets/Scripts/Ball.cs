using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float speed = 5;
	public GameObject trackObj; 
	// Use this for initialization
	IEnumerator Start () {
		rigidbody2D.velocity = Vector2.one.normalized * speed;
		while (true) {
			// 弾をプレイヤーと同じ位置/角度で作成
			Instantiate (trackObj, transform.position, transform.rotation);
			// 0.05秒待つ
			yield return new WaitForSeconds (0.05f);
		}
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
	}
	
	void OnTriggerExit2D(Collider2D c)
	{
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		if (layerName == "GameArea") {
			DestroyBall();
//			CreateNewBall();
		}
	}

	private void CreateNewBall()
	{
		FindObjectOfType<Player> ().CreateBall();
	}

	private void DestroyBall()
	{
		FindObjectOfType<Player> ().DecrementBallCount ();
		Destroy(gameObject);
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
