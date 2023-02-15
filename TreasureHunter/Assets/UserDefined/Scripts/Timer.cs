using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameTime;

    private float seconds, minutes, startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float ellapsedTime = Time.time - startTime;
        minutes = (int)(ellapsedTime / 60f);
        seconds = (int)(ellapsedTime % 60f);
        gameTime.text = "Elapsed Time  " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void ResetTimer()
    {
        startTime = Time.time;
    }
}
