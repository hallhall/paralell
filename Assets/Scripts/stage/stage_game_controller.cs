using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class stage_game_controller : MonoBehaviour {

	public GameObject[] alicia_targets;
	public GameObject target_start_obj;
	public GameObject target_obj;
    public TextAsset m_textAsset;
    public float time = 1.0f;

    public bool can_play = false;

	AudioSource stage1_music;
	AudioSource stage1_song;

    List<float[]> music_score;

	// Use this for initialization
	void Start () {
		target_start_obj.SetActive (false);
		stage1_music = GameObject.Find ("stage1_music").GetComponent<AudioSource> ();
		stage1_song = GameObject.Find ("stage1_song").GetComponent<AudioSource> ();
        music_score = set_music_score();
	}
	
	// Update is called once per frame
	void Update () {
        if (can_play) {

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
            string[] fields = _line.Split(_SPLIT_CHAR);
            float[] _fields = new float[3];
            int counter = 0;
            foreach (string _data in fields) {
                _fields[counter] = float.Parse(_data);
                counter++;
            }
            _music_score.Add(_fields);
        }
        return _music_score;
    }


    //target生成
    void make_target () {
        GameObject _target = Instantiate(target_obj, target_start_obj.transform.position, target_start_obj.transform.rotation) as GameObject;
        _target.GetComponent<target_script>().set_param(time, alicia_targets[0].transform.position);
    }
}