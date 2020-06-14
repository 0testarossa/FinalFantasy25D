﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    private float alpha;
    private float alphaBegin;
    private float time;
    void Start()
    {
        time = 109.5f;
        alpha = 0;
        alphaBegin = 1;
        GameObject.Find("Canvas/Image").GetComponent<Image>().color = new Color(0, 0, 0, 255);
}

    private void Update()
    {
        if (time > 100f)
        {
            if (alphaBegin > 0)
            {
                alphaBegin -= Time.deltaTime * 0.2f;
                GameObject.Find("Canvas/Image").GetComponent<Image>().color = new Color(0, 0, 0, alphaBegin);
            }
        }
        time -= Time.deltaTime;
        /*if (time <= 0)
        {
            if (alpha < 255f)
            {
                alpha += Time.deltaTime * 0.4f;
                GameObject.Find("Canvas/Image").GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            }
        }*/
    }
}
