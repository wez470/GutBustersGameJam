using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	public GUIStyle style;
	public string Word;
	public string FullWord;
	public string Fancy;
	public int correct;
	public char FirstChar;
	public string first;
	// Use this for initialization
	void Start () {
		FirstChar = Word[0];
		first = FirstChar.ToString();
		FullWord = Word;
		correct = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject p = GameObject.FindGameObjectWithTag("Player");
		Vector3 pos = p.transform.position;
		
		Vector3 towards = Vector3.Normalize (pos - transform.position)*5.0f;
		
		this.rigidbody2D.velocity = new Vector2(towards.x, towards.y);
	}
	
	public void SetNewWord(string w){
		Word = w;
		FirstChar = Word[0];
		FullWord = Word;
		Fancy = Fancify (FullWord, 0);
	}
	
	public void SetWord(string w){
		Word = w;
		Fancy = Fancify(w, 0);
	}
	
	public void UpdateFancy(){
		string ss = FullWord.Substring(0,FullWord.Length-Word.Length);
		Fancy = Fancify(ss, 2) + Fancify(Word,0);
	}
	
	public string Fancify(string w, int wrg){
	
		string ret;
	
		switch (wrg){
		
		case 1:
			ret = "<color=#ff0000ff>" + w + "</color>";
			break;
		case 2:
			ret = "<color=#00ff00ff>" + w + "</color>";
			break;
		default:
			ret = "<color=#e0e0e0ff>" + w + "</color>"; 
			break;
			
		}
	
		return ret;
	}
}
