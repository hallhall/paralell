using UnityEngine;
using System.Collections;

public class sample : MonoBehaviour {

    public float speed = 0.1f;
	// Use this for initialization
	void Start () {
        UnityEngine.Debug.Log("sample1");
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey("right")) {
            this.transform.position += transform.right * speed;
        }
        if (Input.GetKey("left")) {
            this.transform.position -= transform.right * speed;
        }
	}
}
