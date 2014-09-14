using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {

	public GameObject line;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StageRoutinMethod(){
		AllLinesForward();
		CreateNewLine();
	}

	void CreateNewLine(){
		var line_clone = Instantiate (line,transform.position, transform.rotation) as GameObject;
		line_clone.transform.parent = transform;
		line_clone.transform.Translate(0,0,0);
	}

	void AllLinesForward(){
		int lines = transform.childCount;
		Debug.Log (lines);

		for (int i = 0; i < lines; i++) {
			Debug.Log ("now child at "+ i);
			Transform child = transform.GetChild (i);
			var c = child.gameObject;
			Debug.Log (c);
			c.GetComponent<SingleLine>().Forward();
		}
	}
}
