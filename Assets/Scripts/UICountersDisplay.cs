using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICountersDisplay : MonoBehaviour
{
    public int targetFrameRate = 60;
    public float refreshTime = 1f;
    TextMeshProUGUI counters;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;

        counters = GetComponent<TextMeshProUGUI>();
        InvokeRepeating(nameof(UpdateCounters), 0, refreshTime);
    }

    // Update is called once per frame
    void UpdateCounters()
    {
        
        float currentFPS = 0;
        currentFPS = (int)(1f / Time.unscaledDeltaTime);

        counters.text = "Memory Used: " + (System.GC.GetTotalMemory(false)/1024)/1024 +"MB" + "\nFPS: " + currentFPS;
    }
}
