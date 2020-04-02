using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowDownFactor = 0.05f; //hur mycket vi saktar ned tiden
    public float slowDownLength = 2; //hur länge tiden saktas ner
    public float speedUpFactor = 1.95f;
    public float speedUpLength = 2;
    public bool isSlowing = false;
    public bool isSpeedingUp = false;
    public bool isNormal = true;

    private float FixedDelta;

    public SpeedCanvas canvas;

    private void Start()
    {
        FixedDelta = Time.fixedDeltaTime;
    }
    private void Update()
    {
        Debug.Log("Fixed Delta time " + Time.fixedDeltaTime); 
        if (Time.timeScale == 1)
        {
            normalTime();
        }
        if (isSlowing)
        {
            Time.timeScale += (1f / slowDownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
        if (isSpeedingUp)
        {
            Time.timeScale -= (1f / speedUpLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 1, 2);
        }

    }
    public void SlowTime()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        isSlowing = true;
        canvas.slowPanel.SetActive(true);
        isNormal = false;
    }
    public void FastTime()
    {
        Time.timeScale = speedUpFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        isSpeedingUp = true;
        canvas.speedPanel.SetActive(true);
        isNormal = false;
    }
    public void normalTime()
    {
        Time.fixedDeltaTime = FixedDelta;
        isNormal = true;
        isSpeedingUp = false;
        isSlowing = false;
        Time.timeScale = 1;
        canvas.speedPanel.SetActive(false);
        canvas.slowPanel.SetActive(false);
    }
}
