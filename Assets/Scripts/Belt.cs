using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    public GameObject belt;
    public Transform endpoint;
    public float speed = 3;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.transform.position, speed * Time.deltaTime);
        if (other.gameObject == player)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, endpoint.transform.position, speed * Time.deltaTime);
        }
    }
}
