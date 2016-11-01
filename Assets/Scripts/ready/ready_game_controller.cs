using UnityEngine;
using System.Collections;
using common;
using UnityEngine.UI;

public class ready_game_controller : MonoBehaviour {
	//unity上のリソース

    AudioSource button_bgm;
    AudioSource return_bgm;

    Text stage_score;
    Text stage_combo;
    Text normal_mode;
    Text classic_mode;
    Text unique_mode;
    Text book_percent;

    SpriteRenderer demo_alice_body;
    SpriteRenderer demo_back_img;
    SpriteRenderer costume_img;
    SpriteRenderer stage_img;
    SpriteRenderer light_img;
    SpriteRenderer now_costume_img;
    SpriteRenderer have_costume_1_img;
    SpriteRenderer have_costume_2_img;
    SpriteRenderer now_stage_img;
    SpriteRenderer have_stage_1_img;
    SpriteRenderer have_stage_2_img;
    SpriteRenderer now_light_img;
    SpriteRenderer have_light_1_img;
    SpriteRenderer have_light_2_img;

    GameObject front_wrap;
	GameObject modal_costume_wrap;
	GameObject modal_stage_wrap;
	GameObject modal_light_wrap;

	ParticleSystem light_particle;

	//動作用
	string[] costumes_str = {"alice_body_1.png", "alice_body_2.png", "alice_body_3.png"};
	string[] stages_str = {"tree_back.png", "house_back.png", "building_back.png"};
	Color[] lights_str = {new Color(254f/255f, 255f/255f, 193f/255f), new Color(254f/255f, 255f/255f, 193f/255f), new Color(254f/255f, 255f/255f, 193f/255f)};
	bool is_modal = false; //モーダルが起動中か否か

    //交換用（モーダルを開いている際に、どのアイテムを選択しているか）
    int now_selected = 0;
    Color selected_color = new Color(255f/255f, 212f/255f, 212f/255f);

	//別画面移動用
	bool is_move = false; //これ付きならば移動
	string to_move_str = ""; //この先へ移動

	// Use this for initialization
	void Start () {
		set_variable();
		set_text();
        set_mordal();
        set_mordal_img();
    }
	
	// Update is called once per frame
	void Update () {
        ready_touch_check();
	}


	//変数セット
	void set_variable () {
		button_bgm = GameObject.Find("button_bgm").GetComponent<AudioSource>();
		return_bgm = GameObject.Find("return_bgm").GetComponent<AudioSource>();
		stage_score = GameObject.Find("stage_score").GetComponent<Text>();
		stage_combo = GameObject.Find("stage_combo").GetComponent<Text>();
		normal_mode = GameObject.Find("normal_mode").GetComponent<Text>();
		classic_mode = GameObject.Find("classic_mode").GetComponent<Text>();
		unique_mode = GameObject.Find("unique_mode").GetComponent<Text>();
		book_percent = GameObject.Find("book_percent").GetComponent<Text>();
		demo_alice_body = GameObject.Find("demo_alice_body").GetComponent<SpriteRenderer>();
		demo_back_img = GameObject.Find("demo_back_img").GetComponent<SpriteRenderer>();
		costume_img = GameObject.Find("costume_img").GetComponent<SpriteRenderer>();
		stage_img = GameObject.Find("stage_img").GetComponent<SpriteRenderer>();
		light_img = GameObject.Find("light_img").GetComponent<SpriteRenderer>();
		now_costume_img = GameObject.Find("now_costume_img").GetComponent<SpriteRenderer>();
		have_costume_1_img = GameObject.Find("have_costume_1_img").GetComponent<SpriteRenderer>();
		have_costume_2_img = GameObject.Find("have_costume_2_img").GetComponent<SpriteRenderer>();
		now_stage_img = GameObject.Find("now_stage_img").GetComponent<SpriteRenderer>();
		have_stage_1_img = GameObject.Find("have_stage_1_img").GetComponent<SpriteRenderer>();
		have_stage_2_img = GameObject.Find("have_stage_2_img").GetComponent<SpriteRenderer>();
		now_light_img = GameObject.Find("now_light_img").GetComponent<SpriteRenderer>();
		have_light_1_img = GameObject.Find("have_light_1_img").GetComponent<SpriteRenderer>();
		have_light_2_img = GameObject.Find("have_light_2_img").GetComponent<SpriteRenderer>();
		front_wrap = GameObject.Find("front_wrap");
		light_particle = GameObject.Find("demo_light_particle").GetComponent<ParticleSystem>();
		modal_costume_wrap = GameObject.Find ("modal_costume_wrap");
		modal_stage_wrap = GameObject.Find ("modal_stage_wrap");
		modal_light_wrap = GameObject.Find ("modal_light_wrap");
	}


	//テキストセット
	void set_text () {
		stage_score.text = "Max Score    : " + sample_save.max_score;
		stage_combo.text = "Max Combo : " + sample_save.max_combo;
		if (sample_save.normal_mode) normal_mode.color = Color.black;
		if (sample_save.clasic_mode) classic_mode.color = Color.black;
		if (sample_save.uniqe_mode) unique_mode.color = Color.black;
		book_percent.text = sample_save.now_book_percent + " %";
	}


	//モーダルセット（データのセット)
	void set_mordal () {
		//コスチューム
		if (!sample_save.have_costume [1]) {
			costumes_str [1] = null;
			have_costume_1_img.sprite = null;
			GameObject.Find ("have_costume_1_tap").SetActive (false);
		}
		if (!sample_save.have_costume [2]) {
			costumes_str [2] = null;
			have_costume_2_img.sprite = null;
			GameObject.Find ("have_costume_2_tap").SetActive (false);
		}
        modal_costume_wrap.SetActive(false);

        //ステージ
        if (!sample_save.have_stage [1]) {
			stages_str [1] = null;
			have_stage_1_img.sprite = null;
			GameObject.Find ("have_stage_1_tap").SetActive (false);
		}
		if (!sample_save.have_stage [2]) {
			stages_str [2] = null;
			have_stage_2_img.sprite = null;
			GameObject.Find ("have_stage_2_tap").SetActive (false);
		}
        modal_stage_wrap.SetActive(false);

        //ライト
        if (!sample_save.have_light [1]) {
			lights_str [1] = Color.clear; //nullだとエラー
			have_light_1_img.sprite = null;
			GameObject.Find ("have_light_1_tap").SetActive (false);
		}
		if (!sample_save.have_light [2]) {
			lights_str [2] = Color.clear;
			have_light_2_img.sprite = null;
			GameObject.Find ("have_light_2_tap").SetActive (false);
		}
        modal_light_wrap.SetActive(false);
    }


	//モーダルウィンドウの画像セット
	void set_mordal_img () {
        //コスチュームのセット
        now_costume_img.sprite = Resources.Load<Sprite>("../Images/ready/"+costumes_str[0]);
        if (costumes_str[1] == null) {
            have_costume_1_img.enabled = false;
        } else {
            have_costume_1_img.sprite = Resources.Load<Sprite>("../Images/ready/" + costumes_str[1]);
            Debug.Log("../Images/ready/" + costumes_str[1]);
        }
        if (costumes_str[2] == null) {
            have_costume_2_img.enabled = false;
        } else {
            have_costume_2_img.sprite = Resources.Load<Sprite>("../Images/ready/" + costumes_str[2]);
        }
        //ステージのセット
        now_stage_img.sprite = Resources.Load<Sprite>("../Images/ready/"+stages_str[0]);
        if (stages_str[1] == null) {
            have_stage_1_img.enabled = false;
        } else {
            have_stage_1_img.sprite = Resources.Load<Sprite>("../Images/ready/" +stages_str[1]);
        }
        if (stages_str[2] == null) {
            have_stage_2_img.enabled = false;
        } else {
            have_stage_2_img.sprite = Resources.Load<Sprite>("../Images/ready/" + stages_str[2]);
        }
        //証明のセット
        now_light_img.color = lights_str[0];
        if (lights_str[1] == Color.clear) {
            have_light_1_img.enabled = false;
        } else {
            have_light_1_img.color = lights_str[1];
        }
        if (lights_str[2] == Color.clear) {
            have_light_2_img.enabled = false;
        } else {
            have_light_2_img.color = lights_str[2];
        }
    }


    //タッチ判定
    void ready_touch_check () {
        string[] touch_key = {"back_btn_tap", "costume_tap", "stage_tap", "light_tap", "start_btn_tap", "have_costume_1_tap", "have_costume_2_tap", "modal_costume_chage_btn_tap" };
        string touch_obj_name = common_method.is_touch_3d_str(touch_key);
        //if (touch_obj_name != "") Debug.Log(touch_obj_name);
        switch (touch_obj_name) {
            case "":
                break;
            case "back_btn_tap":
                ready_anim_tigger.is_move = true;
                ready_anim_tigger.to_move_str = "story";
                break;
            case "costume_tap":
                if (!is_modal) {
                    modal_costume_wrap.SetActive(true);
                    is_modal = true;
                }
                break;
            case "stage_tap":
                if (!is_modal) {
                    modal_stage_wrap.SetActive(true);
                    is_modal = true;
                }
                break;
            case "light_tap":
                if (!is_modal) {
                    modal_light_wrap.SetActive(true);
                    is_modal = true;
                }
                break;
            case "start_btn_tap":
                if (!is_modal) {
                    ready_anim_tigger.is_move = true;
                    ready_anim_tigger.to_move_str = "stage1";//------------------------
                }
                break;
            case "have_costume_1_tap":
                GameObject.Find("have_costume_2_img_frame").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("have_costume_1_img_frame").GetComponent<SpriteRenderer>().color = selected_color;
                now_selected = 1;
                break;
            case "have_costume_2_tap":
                GameObject.Find("have_costume_1_img_frame").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("have_costume_2_img_frame").GetComponent<SpriteRenderer>().color = selected_color;
                now_selected = 2;
                break;
            case "modal_costume_chage_btn_tap":
                if (now_selected != 0) {
                    string before_costume_str = costumes_str[0];
                    costumes_str[0] = costumes_str[now_selected];
                    costumes_str[now_selected] = before_costume_str;
                    now_selected = 0;
                }
                set_mordal_img();
                is_modal = false;
                modal_costume_wrap.SetActive(false);
                break;
        }
    }
}
