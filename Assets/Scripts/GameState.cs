using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameState : MonoBehaviour {

	public Dictionary<char, GameObject> currentEnemies;
	public GameObject currentTarget;
	private Enemy e;

	// Use this for initialization
	void Start () {
		currentEnemies = new Dictionary<char, GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (currentEnemies.Count);
		GetInputCharacters();
		
	}
	
	void OnGUI(){
		TextAboveEnemies();
	}
	
	void GetInputCharacters(){
		string frameInput = Input.inputString;
		
		for (int i = 0; i < frameInput.Length; i++){
			//backspace
			if (frameInput[i] == '\b' && currentTarget != null){
				e.Word = e.FullWord;
				currentTarget = null;
			}
			
			if (currentTarget != null){
				if (e.Word[0] == frameInput[i]){ 
					e.Word = e.Word.Substring (1);
				}
				
				if (e.Word.Length == 0){
					//cleanup enemy will abstract later
					currentEnemies.Remove (e.FirstChar);
					GameObject.Destroy (currentTarget);
					currentTarget = null;
					e = null;
				}
			}
			else
			{
				if (currentEnemies.TryGetValue(frameInput[0], out currentTarget)){
					e = currentTarget.GetComponent<Enemy>();
					e.Word = e.Word.Substring (1);
					
					if (e.Word.Length == 0){
						//cleanup enemy will abstract later
						currentEnemies.Remove (e.FirstChar);
						GameObject.Destroy (currentTarget);
						currentTarget = null;
						e = null;
						
					}
				}
				
			}
			
		}
	}
	
	//update textbox positions above each player
	void TextAboveEnemies(){
		GameObject[] AllEnemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject g in AllEnemies){
			Enemy e = g.GetComponent<Enemy>();
			
			Vector3 above = g.transform.position;
			//needs to be done before converting to screen poitn from world point
			above.y += 2;
			Vector3 camPos = Camera.main.WorldToScreenPoint (above);
			//camPos = new Vector3(Mathf.Clamp (camPos.x, Screen.width),Mathf.Clamp (),camPos.z);
			if (g != null)
			GUI.Label(new Rect((camPos.x-20), (Screen.height - camPos.y+10), 100, 50), e.Word, e.style);
		}
	}
}
