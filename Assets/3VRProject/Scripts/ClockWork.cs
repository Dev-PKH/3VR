using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ClockWork : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform hourHand, minHand, secHand;

    private float delay = 1.0f;
    private float curdelay = 0;
    private int curTime = 0;

    private void Start()
    {
        DateTime now = DateTime.Now;
        curTime = (now.Hour * 3600) + (now.Minute * 60) + now.Second;
        SetTime();
    }

    private void Update()
    {
        if(curdelay >= delay)
        {
            curdelay = 0;
            UpdateTime();
        }

        curdelay += Time.deltaTime;
    }

    private void SetTime()
    {
        // pivot을 중심으로 회전
        hourHand.localRotation = Quaternion.Euler(0, curTime * 360 / 43200, 0);
        minHand.localRotation = Quaternion.Euler(0, curTime * 360 / 3600, 0);
        secHand.localRotation = Quaternion.Euler(0, curTime * 360 / 60, 0);

        // 침들이 시계와 수평하도록 방향을 설정
        hourHand.Rotate(90.0f, hourHand.localRotation.y, -90.0f, Space.World);
        minHand.Rotate(90.0f, minHand.localRotation.y, -90.0f, Space.World);
        secHand.Rotate(90.0f, secHand.localRotation.y, -90.0f, Space.World);
    }

    private void UpdateTime()
    {
        curTime += 1;
        SetTime();
    }
}