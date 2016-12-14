using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextLevel : MonoBehaviour {

	public int level;

	Text text;

	void Awake(){
		text = GetComponent<Text> ();

		level = 1;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		text.text = "Level "+ level;
	
	}
}
