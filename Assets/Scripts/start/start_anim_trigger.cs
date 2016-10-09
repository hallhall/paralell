using UnityEngine;
using System.Collections;

public class start_anim_trigger : MonoBehaviour {
    Animator object_wrap_controller;

    void start () {
       
    }

	public void to_tap_to_start () {
        object_wrap_controller = GameObject.Find("object_wrap").GetComponent<Animator>();
        object_wrap_controller.Play("tap_to_start");
        start_game_controller.can_tap_to_start = true; //tap_to_startを押せるように
    }
}
