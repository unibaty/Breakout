using UnityEngine;
using System.Collections;

public class BallTrack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DestroyOwn(){
		Destroy(gameObject);
	}
}
