using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGun : MonoBehaviour
{
    public GameObject explosion;
    public Camera cam;
    public TimeManager manager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }
    void shoot()
    {
        RaycastHit _hitInfo;
        //om något träffas
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hitInfo))
        {
            Instantiate(explosion, _hitInfo.point, Quaternion.LookRotation(_hitInfo.normal));
            manager.SlowTime();
        }
    }
}
