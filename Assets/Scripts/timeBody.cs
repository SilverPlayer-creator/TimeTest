using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeBody : MonoBehaviour
{

     bool isRewinding = false;

    public float recordTime = 5; //hur länge spelet spelar in information om vart kuberna befann sig

    List<PointInTime> PointsInTime;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        PointsInTime = new List<PointInTime>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isRewinding = true;
            startRewind();
            if (Input.GetKeyUp(KeyCode.Return))
            {
            stopRewind();
            }
        }
    }
    private void FixedUpdate()
    {
        if (isRewinding == true)
        {
            rewind();
        }
        else
        {
            Record();
        }
        void rewind()
        {
            if (PointsInTime.Count > 0)
            {
                PointInTime pointInTime = PointsInTime[0];
                transform.position = pointInTime.position;
                transform.rotation = pointInTime.rotation;
                PointsInTime.RemoveAt(0);
            }
            else
            {
                stopRewind();
            }
        }
        void Record() //record the positions of objects
        {
            if (PointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
            {
                PointsInTime.RemoveAt(PointsInTime.Count - 1);
            }
            PointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
        }
    }
    public void startRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }
    public void stopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
}
