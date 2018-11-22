using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//tumbling an asteroid 
public class RandomRotator : MonoBehaviour
{
    private Rigidbody rb;
    public float tumble;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
