using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpnDown : MonoBehaviour
{
    public int moveInt;
    public float startPos;
    public float endPos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        moveInt = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveInt == 1)
        {
            moveUp();
            if (transform.position.y >= endPos)
            {
                moveInt = 2;
            }
        }
        if (moveInt == 2)
        {
            moveDown();
            if (transform.position.y <= startPos)
            {
                moveInt = 1;
            }
        }
    }
    void moveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    void moveDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
