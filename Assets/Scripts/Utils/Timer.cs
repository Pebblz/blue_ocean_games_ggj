using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Action onTimedOut;
    public float timer;

    public bool oneShot = true;
    private bool start_timer = false;
    private float init_timer;

    // Update is called once per frame
    private void Awake()
    {
        init_timer = timer;
    }
    void Update()
    {
        if (start_timer)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                onTimedOut?.Invoke();

                if (!oneShot)
                {
                    timer = init_timer;
                }
            }
        }
       
    }

    public void setDuration(float value)
    {
        this.timer = value;
        this.init_timer = value;
    }

    public void startTimer()
    {
        start_timer = true;
    }
    public void pauseTimer()
    {
        start_timer = false;
    }
    public void reset()
    {
        timer = init_timer;
    }
}
