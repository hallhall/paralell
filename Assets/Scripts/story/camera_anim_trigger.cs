using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class camera_anim_trigger : MonoBehaviour {
    static public bool is_move; //ここがtrueならばアニメ終了時に移動
    static public string to_move_str; //この値の先へ移動
    public GameObject front_wrap;

    void start() {
        is_move = false;
        front_wrap = GameObject.Find("front_wrap");
    }

	public void end_camera_move() {
        front_wrap.SetActive(true);
        front_wrap.GetComponent<Animator>().Play("end_story");
    }

    public void bgm_start() {
        GameObject bgm = GameObject.Find("story_bgm_wrap");
        bgm.GetComponent<AudioSource>().Play();
    }

    public void story_end() {
        if (is_move) {
            SceneManager.LoadScene(to_move_str);
        }
    }
}
