using UnityEngine;
using System.Collections;
using System;

public class Spawner : MonoBehaviour {
	
	private float curTime;
	private float lastSpawnTime;
	public float spawnRate = 2.0f;
	private float startTime;
	private GameState gs;
	public int mplier;
	public GameObject enemyPF;
	public string[] dict;
	public int idx;
	public int rangeCeil, rangeFloor;
	public int dictFrac;
	// Use this for initialization
	void Start () {
		mplier = 0;
		dict = System.IO.File.ReadAllLines(Application.dataPath + "/Dictionary/dict.txt");
		curTime = Time.time;
		lastSpawnTime = curTime;
		startTime = curTime;
		gs = GameObject.FindGameObjectWithTag("GS").GetComponent<GameState>();
		Array.Sort (dict, (x, y) => x.Length.CompareTo(y.Length));
		dictFrac = dict.Length/20;
	}
	
	// Update is called once per frame
	void Update () {
		curTime = Time.time;
		bool maxDifficulty = false;
		if (Mathf.Abs(curTime - lastSpawnTime) > spawnRate){
			//find a word without an equivalent starting character on the board,
			//instantiate an enemy with that word
			//Dict Search
			Debug.Log (curTime + " " + lastSpawnTime + " " + (curTime-lastSpawnTime) + " " + spawnRate);
			string word = GenerateWord();
			GameObject go = (GameObject) Instantiate (enemyPF, new Vector3(4.0f, -1.7f, 0.0f), Quaternion.identity);
			gs.currentEnemies.Add (word[0], go);
			Enemy e = go.GetComponent<Enemy>();
			e.SetNewWord(word);
			lastSpawnTime = Time.time;
		}
		
		if ((Mathf.Abs(startTime - curTime) > (5+5*mplier)) && !maxDifficulty){
			if (mplier < 19) mplier++;
			if (mplier > 18) maxDifficulty = true;
		}
	}
	
	void ShootAndCleanup(){
	
	}
	
	public string GenerateWord(){
		idx = 0;
		char first = 'a';
		string word;
		rangeCeil = (2*dictFrac)-1+((mplier-1)*dictFrac);
		rangeFloor = mplier*dictFrac;
		do
		{
			idx = UnityEngine.Random.Range(rangeFloor, rangeCeil);
			word = dict[idx];
			first = word.ToCharArray()[0];
			
		}while(gs.currentEnemies.ContainsKey (first));
		return dict[idx];
	}
}
