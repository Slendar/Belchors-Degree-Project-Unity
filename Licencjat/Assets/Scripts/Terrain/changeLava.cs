using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLava : MonoBehaviour
{
    public BoxCollider platform;
    public BoxCollider lava;

    private void OnTriggerEnter(Collider other)
    {
        lava.enabled = true;
        platform.isTrigger = false;
    }
}
