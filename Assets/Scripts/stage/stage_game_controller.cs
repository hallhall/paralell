using UnityEngine;
using System.Collections;

public class stage_game_controller : MonoBehaviour {

	public GameObject[] alicia_targets;
	public GameObject target_start;
	public GameObject target;

	AudioSource stage1_music;
	AudioSource stage1_song;


	// Use this for initialization
	void Start () {
		target_start.SetActive (false);
		stage1_music = GameObject.Find ("stage1_music").GetComponent<AudioSource> ();
		stage1_song = GameObject.Find ("stage1_song").GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
