﻿using UnityEngine;
using System.Collections;

public class PlayShotgunSound : MonoBehaviour {

	public AudioClip ac;
	
	void Awake() {
		
	}
	
	public void Pray(){
		AudioSource.PlayClipAtPoint (ac, this.transform.position, 0.075f);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
