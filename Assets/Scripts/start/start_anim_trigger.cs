using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class start_anim_trigger : MonoBehaviour {
    Animator object_wrap_controller;
    public Animator front_wrap_controller;
    public GameObject front_wrap;
    static public bool is_move; //ここがtrueならばアニメ終了時に移動
    static public string to_move_str; //この値の先へ移動

    void start () {
        front_wrap = GameObject.Find("front_wrap");
        front_wrap_controller = front_wrap.GetComponent<Animator>();
    }

	public void to_tap_to_start () {
        object_wrap_controller = GameObject.Find("object_wrap").GetComponent<Animator>();
        object_wrap_controller.Play("tap_to_start");
        start_game_controller.can_tap_to_start = true; //tap_to_startを押せるように
        GameObject.Find("front_wrap").SetActive(false);
    }

    public void story_end() {
        if (is_move) {
            is_move = false;
            SceneManager.LoadScene(to_move_str);
        }
    }

    public void tap_story_end() {
        front_wrap.SetActive(true);
        front_wrap_controller.Play("start_end");
    }
}
