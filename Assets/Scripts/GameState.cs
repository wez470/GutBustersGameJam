using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameState : MonoBehaviour {

	public Dictionary<char, GameObject> currentEnemies;
	public GameObject currentTarget;
	private Enemy e;
	public Spawner sp;
	public Player ch;
	public GUIStyle scoreStyle;
	int Score;

	// Use this for initialization
	void Start () {
		currentEnemies = new Dictionary<char, GameObject>();
		sp = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
		ch = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		GetInputCharacters();
		
	}
	
	void OnGUI(){
		TextAboveEnemies();
		DrawScore();
	}
	
	void DrawScore(){
		Rect r = new Rect(Screen.width - 100, 25, 100, 50);
		
		DrawOutline(r,"Score: " + Score, 2, scoreStyle);
		GUI.Label(r, "Score: " + Score, scoreStyle);
	}
	
	void GetInputCharacters(){
		string frameInput = Input.inputString;
		
		for (int i = 0; i < frameInput.Length; i++){
			//backspace
			if (frameInput[i] == '\b' && currentTarget != null){
				e.Word = e.FullWord;	
				e.UpdateFancy();
			}
			
			if (currentTarget != null){
				if (e.Word[0] == frameInput[i]){ 
					e.Word = e.Word.Substring (1);
					e.UpdateFancy();
				}
				else
				{
					//currentEnemies.Remove (e.FirstChar);
					e.SetNewWord(e.FullWord);
					//currentEnemies.Add (e.FirstChar, currentTarget);
					currentTarget = null;
				}
				
				if (e.Word.Length == 0){
					//cleanup enemy will abstract later
					ShootAndCleanup();
				}
			}
			else
			{
				if (currentEnemies.TryGetValue(frameInput[0], out currentTarget)){
					e = currentTarget.GetComponent<Enemy>();
					e.Word = e.Word.Substring (1);
					e.UpdateFancy();
					
					if (e.Word.Length == 0){
						//cleanup enemy will abstract later
						ShootAndCleanup();
						
					}
				}
				
			}
			
		}
	}
	
	void ShootAndCleanup(){
		currentEnemies.Remove (e.FirstChar);
		ch.StartShooting();
		e.BustGut();
		Score++;
		currentTarget = null;
		e = null;
	}
	
	//update textbox positions above each player
	void TextAboveEnemies(){
		GameObject[] AllEnemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject g in AllEnemies){
			Enemy e = g.GetComponent<Enemy>();
			
			Vector3 above = g.transform.position;
			//needs to be done before converting to screen poitn from world point
			above.y += 3;
			Vector3 camPos = Camera.main.WorldToScreenPoint (above);
			//camPos = new Vector3(Mathf.Clamp (camPos.x, Screen.width),Mathf.Clamp (),camPos.z);
			if (g != null && e != null){
				Rect r = new Rect((camPos.x-20), (Screen.height - camPos.y+10), 100, 50);
				
				DrawOutline(r,e.FullWord, 2, e.style);
				GUI.Label (r,e.Fancy,e.style);
			}
		}
	}
	
	void DrawOutline(Rect r,string t,int strength,GUIStyle style){
		GUI.color=new Color(0,0,0,1);
		int i;
		for (i=-strength;i<=strength;i++){
			GUI.Label(new Rect(r.x-strength,r.y+i,r.width,r.height),t,style);
			GUI.Label(new Rect(r.x+strength,r.y+i,r.width,r.height),t,style);
		}for (i=-strength+1;i<=strength-1;i++){
			GUI.Label(new Rect(r.x+i,r.y-strength,r.width,r.height),t,style);
			GUI.Label(new Rect(r.x+i,r.y+strength,r.width,r.height),t,style);
		}
		GUI.color=new Color(1,1,1,1);
	}
}
