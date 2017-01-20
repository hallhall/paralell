using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class stage_game_controller : MonoBehaviour {

	public GameObject[] alicia_targets;
	public GameObject[] cat_targets;
	public GameObject[] target_start_obj;
	public GameObject[] target_obj;
    public TextAsset m_textAsset;
    public float speed = 1.0f;

    public bool can_play = false;
	public bool is_first = true;

	private float now_music_time;
	private float end_music_time;

	AudioSource stage1_music;
	AudioSource stage1_song;

    List<float[]> music_score;
	int music_score_count = 0; //現在何個目の譜面か

	// Use this for initialization
	void Start () {
		Debug.Log ("i");
		for (int i = 0; i < target_start_obj.Length; i++) {
			target_start_obj[i].SetActive (false);
		}
		stage1_music = GameObject.Find ("stage1_music").GetComponent<AudioSource> ();
		stage1_song = GameObject.Find ("stage1_song").GetComponent<AudioSource> ();
		end_music_time = stage1_music.clip.length;
		now_music_time = 0.0f;
        music_score = set_music_score();

	}
	
	// Update is called once per frame
	void Update () {
        if (can_play) {
			music_start (); //最初の音楽スタート
			now_music_time = stage1_music.time; //現在の生成時間所得
			if (check_make_target()) make_target();
        }
    }


    //csvから譜面読み込み
    List<float[]> set_music_score() {
        List<float[]> _music_score = new List<float[]>();

        //テキスト読み込み
        char _SPLIT_CHAR = ',';
        StringReader _sr = new StringReader(m_textAsset.text);
        string _line;
        TextReader reader = _sr;
        while ((_line = reader.ReadLine()) != null) {
            string[] fields = _line.Split(_SPLIT_CHAR); //一行を区切りでデータ格納
            float[] _fields = new float[3]; 
            int counter = 0;
            foreach (string _data in fields) {
                _fields[counter] = float.Parse(_data);
                counter++;
            }
            _music_score.Add(_fields);
			Debug.Log (_fields [0] + "," + _fields [1]);
        }
		Debug.Log ("a");
        return _music_score;
    }


    //target生成
	void make_target () { //誰の（キャラクター） どのターゲットへ移動するか(６方向)
		//指定したキャラクターのターゲットの場所にターゲット生成
		int _who = (int)music_score[music_score_count][2];
		int _target_num = (int)music_score[music_score_count][1];
		GameObject _target = Instantiate(target_obj[_who], target_start_obj[_who].transform.position, target_start_obj[_who].transform.rotation) as GameObject;
		_target.GetComponent<target_script>().set_param(speed, alicia_targets[_target_num].transform.position); //ターゲットの移動先をセット
		music_score_count++;
    }


	//target生成チェック
	bool check_make_target () {
		if (now_music_time <= music_score [music_score_count] [0]) { //再生時間が譜面の記録時間を超えたら
			return true;
		}
		return false;
	}


	//first_music_start
	IEnumerator music_start () {
		if (is_first) {
			is_first = false;
			stage1_song.Play ();
			yield return new WaitForSeconds(2); //2秒待つ（テスト用）
			stage1_music.Play();
		}
	}
}