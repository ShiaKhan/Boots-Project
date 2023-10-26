using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Moverment : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float mainThrust = 1000;
    [SerializeField] float rotationThrust = 1f;

    [SerializeField] ParticleSystem MainParticales;
    [SerializeField] ParticleSystem LeftParticales;
    [SerializeField] ParticleSystem RightParticales;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThurst();
        ProcessRotation();
    }
    
    public void ProcessThurst()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
                
            if(!MainParticales.isPlaying)
            {
                MainParticales.Play();
            }
        }
        else
        {
            MainParticales.Stop();
        }
    }

    public void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(rotationThrust);
            Debug.Log("is move a");
            if(!LeftParticales.isPlaying)
            {
                LeftParticales.Play();
            }
        }
        else if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(-rotationThrust);
            Debug.Log("is move D");
            if(!RightParticales.isPlaying)
            {
                RightParticales.Play();
            }
        }
        else
        {
            LeftParticales.Stop();
            RightParticales.Stop();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(-Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
