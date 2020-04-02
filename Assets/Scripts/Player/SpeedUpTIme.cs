using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpTIme : MonoBehaviour
{
    public TimeManager manager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpeedUp();
        }
    }
    void SpeedUp()
    {
        manager.FastTime();
    }
}
