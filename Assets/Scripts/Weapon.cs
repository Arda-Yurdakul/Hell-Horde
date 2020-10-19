using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using static UnityEngine.ParticleSystem;

public class Weapon: MonoBehaviour
{
    public Camera myCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FireWeapon();
    }

    private void FireWeapon()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(myCamera.transform.position, myCamera.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(myCamera.transform.position, myCamera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                print(hit.collider.gameObject.name);
            }
            else
            {
                Debug.DrawRay(myCamera.transform.position, myCamera.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            }
        }
    }
}
