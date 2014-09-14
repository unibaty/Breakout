using UnityEngine;
using System.Collections;

public class SingleLine : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.childCount == 0){
			DestroyOwn();
		}
	}

	void DestroyOwn(){
		Destroy(gameObject);
	}

	public void Forward(){
		transform.Translate(0,-1,0);
	}
}
