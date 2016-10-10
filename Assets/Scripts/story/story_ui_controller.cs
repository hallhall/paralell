using UnityEngine;
using System.Collections;
using common;

public class story_ui_controller : MonoBehaviour {

    public int stage_count = 3; //ステージの数
    int selected_btn = 1; //選択されているボタン 1~5
    GameObject[] pick_ups; //ボタン上のマーク
    AudioSource btn_bgm;
    AudioSource story_bgm;
    AudioSource return_bgm;

	// Use this for initialization
	void Start () {
        btn_bgm = GameObject.Find("btn_bgm_wrap").GetComponent<AudioSource>();
        story_bgm = GameObject.Find("story_bgm_wrap").GetComponent<AudioSource>();
        return_bgm = GameObject.Find("return_bgm_wrap").GetComponent<AudioSource>();
        pick_ups = new GameObject[stage_count];
	    for(int i=1; i<=stage_count; i++) {
            string _obj_name = "stage" + i + "_pick_up";
            pick_ups[i - 1] = GameObject.Find(_obj_name);
            pick_ups[i - 1].SetActive(false);
        }
        pick_ups[0].SetActive(true);
	}

    // Update is called once per frame
    void Update() {
        //タッチされたか判定
        if (Input.GetMouseButtonDown(0)) {                              
            //ボタンがタッチされたか判定
            for (int i=1; i<=stage_count; i++) {
                string _obj_name = "stage" + i + "_tap";
                if (common_method.is_touch_3d(_obj_name)) {
                    if (selected_btn == i ) {
                        //今だけ
                        if (selected_btn == 1) {
                            camera_anim_trigger.is_move = true;
                            camera_anim_trigger.to_move_str = "ready";
                            btn_bgm.Play();
                            story_bgm.Stop();
                            GameObject.Find("GameObject").GetComponent<Animator>().Play("camera_move");
                        }
                    } else {
                        pick_ups[selected_btn - 1].SetActive(false);
                        selected_btn = i;
                        pick_ups[selected_btn - 1].SetActive(true);
                    }
                }
            }
            //return
            if (common_method.is_touch_3d("back_btn_tap")) {
                camera_anim_trigger.is_move = true;
                camera_anim_trigger.to_move_str = "start_scene";
                return_bgm.Play();
                story_bgm.Stop();
                GameObject.Find("front_wrap").GetComponent<Animator>().Play("end_story");
            }
        }
    }

}
