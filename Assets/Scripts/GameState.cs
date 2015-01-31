using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){
		TextAboveEnemies();
	}
	
	void TextAboveEnemies(){
		GameObject[] AllEnemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject g in AllEnemies){
			Enemy e = g.GetComponent<Enemy>();
			
			Vector3 above = g.transform.position;
			//needs to be done before converting to screen poitn from world point
			above.y += 2;
			Vector3 camPos = Camera.main.WorldToScreenPoint (above);
			//camPos = new Vector3(Mathf.Clamp (camPos.x, Screen.width),Mathf.Clamp (),camPos.z);
			
			GUI.Label(new Rect((camPos.x-20), (Screen.height - camPos.y+10), 100, 50), e.word, e.style);
		}
	}
}
