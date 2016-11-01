using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ready_anim_tigger : MonoBehaviour {
    static public bool is_move; //ここがtrueならばアニメ終了時に移動
    static public string to_move_str; //この値の先へ移動

    public void ready_end() {
        if (is_move) {
            is_move = false;
            SceneManager.LoadScene(to_move_str);
        }
    }
}
