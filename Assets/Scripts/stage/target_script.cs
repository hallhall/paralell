using UnityEngine;
using System.Collections;

public class target_script : MonoBehaviour {

    private float time = 1;
    private Vector3 endPosition;
    private float startTime;
    private Vector3 startPosition;


    // Use this for initialization
    void Start () {
        if (time <= 0) {
            transform.position = endPosition;
            enabled = false;
            return;
        }
        startTime = Time.timeSinceLevelLoad;
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        var diff = Time.timeSinceLevelLoad - startTime;
        if (diff > time) {
            transform.position = endPosition;
            enabled = false;
        }
        var rate = diff / time;
        transform.position = Vector3.Lerp(startPosition, endPosition, rate);
	}

    //情報
    public void set_param (float _time, Vector3 _end_position) {
        time = _time;
        endPosition = _end_position;
    }
}
