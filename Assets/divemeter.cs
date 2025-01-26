using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class divemeter : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public float depthScale = 1.0f;
    void Start()
    {
        text.text = "Start!";
    }

    // Update is called once per frame
    void Update()
    {
        int depth = (int)Math.Round(GameObject.Find("player1").transform.position.y * depthScale, 0);
        depth = depth > 0 ? 0 : -depth;
        text.text = depth.ToString() + "m";
    }
}
