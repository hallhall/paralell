﻿using UnityEngine;
using common;
using System.Collections;

public class start_game_controller : MonoBehaviour {
    Animator front_wrap_controller;
    Animator object_wrap_controller;
    AudioSource tap_to_start_music;
    AudioSource bird_music;
    public static bool can_tap_to_start;
    

	// Use this for initialization
	void Start () {
        front_wrap_controller = GameObject.Find("front_wrap").GetComponent<Animator>();
        object_wrap_controller = GameObject.Find("object_wrap").GetComponent<Animator>();
        tap_to_start_music = GameObject.Find("tap_to_start_music").GetComponent<AudioSource>();
        bird_music = GameObject.Find("bird_music").GetComponent<AudioSource>();
        front_wrap_controller.Play("game_start");
        can_tap_to_start = false;
	}
	
	// Update is called once per frame
	void Update () {
        //tap_to_startの判定
        if ((can_tap_to_start == true) && (common_method.is_touch("tap_to_text"))) {
            tap_to_start_music.Play();
            bird_music.Play();
            can_tap_to_start = false;
            object_wrap_controller.Play("game_ready");
        }
        if ((common_method.is_touch_3d("story_btn")) || (common_method.is_touch_3d("mon_tap"))) {
            start_anim_trigger.is_move = true;
            start_anim_trigger.to_move_str = "story";
            object_wrap_controller.Play("tap_story");

        }
        if ((common_method.is_touch_3d("")) || (common_method.is_touch_3d(""))) {

        }
        if ((common_method.is_touch_3d("")) || (common_method.is_touch_3d(""))) {

        }
        if ((common_method.is_touch_3d("")) || (common_method.is_touch_3d(""))) {

        }

    }


}
