using UnityEngine;
using System.Collections;
using common;
using UnityEngine.UI;

public class ready_game_controller : MonoBehaviour {

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

    Particle light_particle;

	// Use this for initialization
	void Start () {
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
        light_particle = GameObject.Find("demo_light_particle").GetComponent<Particle>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
