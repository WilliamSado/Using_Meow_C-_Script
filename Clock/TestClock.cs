using System;//Include system package
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClock : MonoBehaviour
{
    // 定义时、分、秒针对象
    Transform s_obj;
    Transform m_obj;
    Transform h_obj;
    float timer;//7.
    AudioSource audio;//12
	// Use this for initialization
	void Start () {
        DateTime t = DateTime.Now;//Get system time

        float second = t.Second;
        float minute = t.Minute + second / 60.0f;
        float hour = (t.Hour % 12) + minute / 60.0f;

        h_obj = GameObject.Find("h").transform;
        m_obj = GameObject.Find("m").transform;
        s_obj = GameObject.Find("s").transform;

        //Get the true angle
        s_obj.transform.eulerAngles = new Vector3(0, 0, second * 6);
        m_obj.transform.eulerAngles = new Vector3(0, 0, minute * 6);
        h_obj.transform.eulerAngles = new Vector3(0, 0, hour * 30f);

        timer = Time.time; //Initial assignment

        audio = GameObject.Find("Clock_AudioSource").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Time.time >= timer)
        {
            audio.Play(); //Play audio source
            s_obj.transform.Rotate(Vector3.forward, 6.0f);
            m_obj.transform.Rotate(Vector3.forward, 6 / 60.0f);
            h_obj.transform.Rotate(Vector3.forward, 60 / (12 * 60f));

            timer = Time.time + 1;
        }
    }
}
