using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float delay = 3; //hur lång tid det tar får explosion att äga rum
    public float blastRadius = 5;
    public float force = 700;

    public GameObject explosionEffect; //explosions effekt
    float countdown;
    bool hasExploded; //om explosion har hänt

    public TimeManager timemanager;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasExploded)
        {
            explode();
            hasExploded = true;
        }
    }
    void explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

       Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius); //hitta nära objekt
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody RB = nearbyObject.GetComponent<Rigidbody>();
            if (RB != null)
            {
                RB.AddExplosionForce(force, transform.position, blastRadius);
            }
            //skada
        }
        Destroy(gameObject);
    }
}
