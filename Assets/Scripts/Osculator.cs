using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Osculator : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] float period = 2f;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float movermentFactor;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycle = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycle * tau);

        movermentFactor = (rawSinWave + 1f) /2f;
        Vector3 offset = movementVector * movermentFactor;
        transform.position = startPosition + offset;
        
    }
}
