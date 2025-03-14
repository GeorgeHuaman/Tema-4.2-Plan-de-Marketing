using SpatialSys.UnitySDK;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : SpatialNetworkBehaviour, IVariablesChanged
{
    public static Timer instance;
    public TMP_Text text;
    private NetworkVariable<float> countdownTime = new(initialValue: 10f);
    private bool isRunning = false;
    public SpatialSFX sfx;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateText();
        if (isRunning)
        {
            CountDown();
        }
    }
    public void StartTimer()
    {
        isRunning = true;
        countdownTime.value = 10f;
    }
    public void CountDown()
    {
        countdownTime.value -= Time.deltaTime;

        if (countdownTime <= 0)
        {
            countdownTime.value = 0;
            isRunning = false;
        }
    }
    public void Stop()
    {
        isRunning = false;
    }
    public void OnVariablesChanged(NetworkObjectVariablesChangedEventArgs args)
    {
        
        if (args.changedVariables.ContainsKey(countdownTime.id))
        {
            UpdateText();
        }
        if (args.changedVariables.ContainsKey(countdownTime.id) && countdownTime.value<=0)
        {
            SpatialBridge.audioService.PlaySFX(sfx);
        }
    }
    private void UpdateText()
    {
        int seconds = Mathf.FloorToInt(countdownTime.value);
        int centiseconds = Mathf.FloorToInt((countdownTime.value - seconds) * 100);

        if (centiseconds >= 100)
            centiseconds = 99;

        text.text = $"{seconds:00}.{centiseconds:00}";
    }
}
