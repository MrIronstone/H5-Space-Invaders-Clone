using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform muzzleTransform;
    [SerializeField] private GameObject bulletType;
    [SerializeField] private ParticleSystem fireParticle;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip fireSoundEffect;

    [SerializeField] private float rightAndLeftMoveBoundries;


    [SerializeField] private float strafeSpeed;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Fire();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight(strafeSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft(strafeSpeed);
        }

    }
    public void Fire()
    {
        ParticleSystem muzzleFlash = Instantiate(fireParticle, muzzleTransform.position, Quaternion.identity);
        GameObject newBullet = Instantiate(bulletType, muzzleTransform.position, Quaternion.identity);
        //ParticleSystem newFireParticle = Instantiate(fireParticle);
        //audioSource.PlayOneShot(fireSoundEffect);
    }

    public void MoveLeft(float strafeSpeed)
    {
        if ( (transform.position.x > -rightAndLeftMoveBoundries) && GameManager.instance.isGameRunning)
        {
            transform.Translate(Vector3.left * strafeSpeed * Time.deltaTime);
        }
    }

    public void MoveRight(float strafeSpeed)
    {
        if ( (transform.position.x < rightAndLeftMoveBoundries) && GameManager.instance.isGameRunning)
        {
            transform.Translate(Vector3.right * strafeSpeed * Time.deltaTime);
        }

    }
}
