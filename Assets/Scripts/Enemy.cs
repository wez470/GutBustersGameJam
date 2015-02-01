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
	public bool Dying;
	public AudioClip guts;
	public AudioClip guts2;
	public AudioClip groan;
	AudioClip[] gutsArr;
	private int whichGuts;
	Animator a;
	// Use this for initialization
	void Start () {
		FirstChar = Word[0];
		first = FirstChar.ToString();
		FullWord = Word;
		correct = 0;	
		a = GetComponent<Animator>();
		Dying = false;
		gutsArr = new AudioClip[2];
		gutsArr[0] = guts;
		gutsArr[1] = guts2;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject p = GameObject.FindGameObjectWithTag("Player");
		Vector3 pos = p.transform.position;
		
		Vector3 towards = Vector3.Normalize (pos - transform.position)*2.0f;
		if (!Dying){
			this.rigidbody2D.velocity = new Vector2(towards.x, towards.y);
		}
		else
		{
			this.rigidbody2D.velocity = new Vector2(0, 0);
		}
	}
	
	public void BustGut(){
		a.SetBool("Dying",true);
		Dying = true;
		AudioSource.PlayClipAtPoint(gutsArr[Random.Range (0,2)],transform.position,0.75f);
	}
	
	public void PlayAudio(){
		
		AudioSource.PlayClipAtPoint(groan, transform.position);
	}
	
	public void Dead(){
		a.SetBool("Dying",false);
		Destroy(this.gameObject);
	}
	
	public void SetNewWord(string w){
		Debug.Log ("word: " + w);
		Word = w;
		FirstChar = Word[0];
		FullWord = w;
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
