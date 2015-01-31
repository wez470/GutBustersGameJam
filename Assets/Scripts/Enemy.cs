using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	public GUIStyle style;
	public string Word;
	public string FullWord;
	public char FirstChar;
	public string first;
	// Use this for initialization
	void Start () {
		FirstChar = Word[0];
		first = FirstChar.ToString();
		FullWord = Word;	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject p = GameObject.FindGameObjectWithTag("Player");
		Vector3 pos = p.transform.position;
		
		Vector3 towards = Vector3.Normalize (pos - transform.position)*5.0f;
		
		this.rigidbody2D.velocity = new Vector2(towards.x, towards.y);
	}
	
	public void GiveWord(string w){
		Word = w;
		FirstChar = Word[0];
		FullWord = Word;
	}
}
