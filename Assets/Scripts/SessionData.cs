using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionData : MonoBehaviour
{
    public static SessionData instance;

    public bool BooleanaQualquer;
    public float TimerQualquer;


    void Update()
    {
        if (BooleanaQualquer)
            TimerQualquer += Time.deltaTime;
    }
}
