using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMove : MonoBehaviour
{
    private Transform sun;

    private float curTime = 0;
    private float moveTime = 0;

    private float delay = 1.0f;
    private float curdelay = 0;

    void Start()
    {
        sun = transform;

        DateTime now = DateTime.Now;
        curTime = (now.Hour * 3600) + (now.Minute * 60) + now.Second;
        SunStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (curdelay >= delay)
        {
            curdelay = 0;
            UpdateTime();
        }

        curdelay += Time.deltaTime;
    }

    void SunStart()
    {
        if (curTime <= 21600) // 0시 - 6시
        {
            moveTime = 270 + (Mathf.Abs(curTime) * (90f / 21600f));
        }
        else if (curTime <= 43200) // 6시  - 12시
        {
            moveTime = Mathf.Abs(curTime - 21600) * (120f / 21600f);
        }
        else if (curTime <= 64800) // 12시 - 18시
        {
            moveTime = 120 + (Mathf.Abs(curTime - 43200) * (60f / 21600f));
        }
        else if (curTime <= 86400) // 18시 - 24시
        {
            moveTime = 180 + (Mathf.Abs(curTime - 64800) * (90f / 21600f));
        }

        if (moveTime == 360)
            moveTime = 0;

        sun.rotation = Quaternion.Euler(moveTime, 0, 0);
    }

    void SunRotate()
    {
        if (curTime <= 21600) // 0시 - 6시
        {
            moveTime += (90f / 21600f);
        }
        else if (curTime <= 43200) // 6시  - 12시
        {
            moveTime += (120f / 21600f);
        }
        else if (curTime <= 64800) // 12시 - 18시
        {
            moveTime += (60f / 21600f);
        }
        else if (curTime <= 86400) // 18시 - 24시
        {
            moveTime += (90f / 21600f);
        }
        sun.rotation = Quaternion.Euler(moveTime, 0, 0);
    }

    private void UpdateTime()
    {
        curTime += 1;
        SunRotate();
    }
}