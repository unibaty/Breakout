using UnityEngine;
using System.Collections;

public class GameArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D (Collider2D c)
	{
		Debug.Log ("GameArea exit");
//		c.gameObject.rigidbody2D.velocity = new Vector2(0, 0);//stop
	} 
}
