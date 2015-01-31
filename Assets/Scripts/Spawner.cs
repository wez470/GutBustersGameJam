using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	private float curTime;
	private float lastSpawnTime;
	public float spawnRate = 5.0f;
	private GameState gs;
	public GameObject enemyPF;
	public string[] dict;
	// Use this for initialization
	void Start () {
	
		dict = System.IO.File.ReadAllLines(Application.dataPath + "/Dictionary/dict.txt");
		curTime = Time.time;
		lastSpawnTime = curTime;
		gs = GameObject.FindGameObjectWithTag("GS").GetComponent<GameState>();
	}
	
	// Update is called once per frame
	void Update () {
		curTime = Time.time;
		if (Mathf.Abs(curTime - lastSpawnTime) > spawnRate){
			//find a word without an equivalent starting character on the board,
			//instantiate an enemy with that word
			//Dict Search
			Debug.Log (curTime + " " + lastSpawnTime + " " + (curTime-lastSpawnTime) + " " + spawnRate);
			string word = GenerateWord();
			GameObject go = (GameObject) Instantiate (enemyPF, new Vector3(20.0f, -6.5f, 0.0f), Quaternion.identity);
			gs.currentEnemies.Add (word[0], go);
			Enemy e = go.GetComponent<Enemy>();
			e.GiveWord(word);
			lastSpawnTime = Time.time;
		}
	}
	
	string GenerateWord(){
		int idx = 0;
		char first = 'a';
		string word;
		do
		{
			idx = Random.Range(0, dict.Length-1);
			Debug.Log (idx);
			word = dict[idx];
			Debug.Log (word);
			Debug.Log(gs.currentEnemies == null);
			first = word.ToCharArray()[0];
			
		}while(gs.currentEnemies.ContainsKey (first));
		return dict[idx];
	}
}
