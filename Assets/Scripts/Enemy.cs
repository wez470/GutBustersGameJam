using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	public GUIStyle style;
	public string word;
	// Use this for initialization
	void Start () {
		word = "bakgsdf";
	}
	
	// Update is called once per frame
	void Update () {
		GameObject p = GameObject.FindGameObjectWithTag("Player");
		Vector2 pos = p.transform.position;
		
		
		
	}
}
