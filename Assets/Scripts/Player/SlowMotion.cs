using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public TimeManager timeManager;
    public bool isSlowing = false;

    private void Update()

    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            doSlowMotion();
        }
    }
    void doSlowMotion()
    {
        timeManager.SlowTime();
        isSlowing = true;
    }
}
