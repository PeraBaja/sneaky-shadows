using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    float _timeLeft;
    float _initalTime;
    public bool TimeIsOut { get; private set; }
    bool _isOneShot; //If its true: the timer only will be executed one time. In otherwise the timer will be reset
    public Timer(float seconds, bool isOneShot = false)
    {
        _initalTime = seconds;
        _timeLeft = _initalTime;
        _isOneShot = isOneShot;
    }
    public void UpdateTimer()
    {
        CountDown();
        IsTimeOut();

        if (_isOneShot) return;
        ResetTimer();
    }
    void CountDown()
    {
        _timeLeft -= Time.deltaTime;
    }
    public void ResetTimer()
    {
        _timeLeft = _initalTime;
    }

    void IsTimeOut()
    {
        if (_timeLeft >= 0)
        {
            TimeIsOut = false;
            return;
        }
        TimeIsOut = true;
    }
}
