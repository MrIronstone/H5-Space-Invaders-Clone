using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private ParticleSystem launchEffect;
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private Rigidbody rb;
    private ParticleSystem rocketLaunch;

    private void Start()
    {
        launchEffect.Play();
    }
    private void FixedUpdate()
    {
        rb.angularVelocity = new Vector3(0, 5, 0);
        rb.AddForce(new Vector3(0, 1, 0), ForceMode.Impulse);
        // rocketLaunch.gameObject.transform.position = this.transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundry"))
        {
            Destroy(gameObject);
        }
        if(other.CompareTag("Enemy"))
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
