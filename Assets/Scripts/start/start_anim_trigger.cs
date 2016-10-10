using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class start_anim_trigger : MonoBehaviour {
    Animator object_wrap_controller;
    Animator front_wrap_controller;
    static public bool is_move; //ここがtrueならばアニメ終了時に移動
    static public string to_move_str; //この値の先へ移動

    void start () {
        front_wrap_controller = GameObject.Find("front_wrap").GetComponent<Animator>();
    }

	public void to_tap_to_start () {
        object_wrap_controller = GameObject.Find("object_wrap").GetComponent<Animator>();
        object_wrap_controller.Play("tap_to_start");
        start_game_controller.can_tap_to_start = true; //tap_to_startを押せるように
        GameObject.Find("front_wrap").SetActive(false);
    }

    public void story_end() {
        if (is_move) {
            SceneManager.LoadScene(to_move_str);
        }
    }

    public void tap_story() {
        Debug.Log("j");
        is_move = true;
        to_move_str = "story";
        front_wrap_controller.Play("start_end");
    }
}
