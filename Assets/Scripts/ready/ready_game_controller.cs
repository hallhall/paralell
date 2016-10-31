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
	string[] costumes_str = {"alice_body_1", "alice_body_2", "alice_body_3"};
	string[] stages_str = {"tree_back", "house_back", "building_back"};
	Color[] lights_str = {new Color(254f/255f, 255f/255f, 193f/255f), new Color(254f/255f, 255f/255f, 193f/255f), new Color(254f/255f, 255f/255f, 193f/255f)};
	bool is_modal = false; //モーダルが起動中か否か

	//別画面移動用
	bool is_move = false; //これ付きならば移動
	string to_move_str = ""; //この先へ移動

	// Use this for initialization
	void Start () {
		set_variable();
		set_text();

    }
	
	// Update is called once per frame
	void Update () {
		if (is_modal) { //モーダル起動中
			if (common_method.is_touch_3d ("back_btn_tap")) { //returnボタンタップ
				is_move = true;
				to_move_str = "story";
				Debug.Log ("back");
			}
		} else { //モーダル停止
			
		}

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
		modal_costume_wrap.SetActive (false);
		modal_stage_wrap = GameObject.Find ("modal_stage_wrap");
		modal_stage_wrap.SetActive (false);
		modal_light_wrap = GameObject.Find ("modal_light_wrap");
		modal_light_wrap.SetActive (false);
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

		//ライト
		if (!sample_save.have_light [1]) {
			lights_str [1] = Color.clear; //nullだとエラー
			have_light_1_img.sprite = null;
			GameObject.Find ("have_lihgt_1_tap").SetActive (false);
		}
		if (!sample_save.have_light [2]) {
			lights_str [2] = Color.clear;
			have_light_2_img.sprite = null;
			GameObject.Find ("have_lihgt_2_tap").SetActive (false);
		}
	}

	//モーダルウィンドウの画像セット
	void set_mordal_img () {

	}
}
