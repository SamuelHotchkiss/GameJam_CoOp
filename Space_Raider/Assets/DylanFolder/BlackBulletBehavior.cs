﻿using UnityEngine;
using System.Collections;

public class BlackBulletBehavior : MonoBehaviour
{

    public Vector3 direction;
    public float speed;
    public float damage;

    public GameObject explosion;
    public AudioClip fire;
    public AudioClip die;
    public float LifeTime = 2;
    float HowLongLive = 0;
    void Start()
    {
        djScript.sounds.PlayOneShot(fire);

        // to prevent staying in scene for too long if hit nothing
        Destroy(gameObject, 5.0f);
    }

    void Update()
    {
        HowLongLive += Time.deltaTime;
        if(HowLongLive < LifeTime)
        {
             Vector3 dir = direction * speed * Time.deltaTime;
             transform.Translate(dir);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            Object obj = Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(obj, 0.5f);

            Destroy(gameObject);
        }
    }
}
