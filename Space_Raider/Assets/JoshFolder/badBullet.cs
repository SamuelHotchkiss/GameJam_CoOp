﻿using UnityEngine;
using System.Collections;

public class badBullet : MonoBehaviour 
{

    public Vector3 direction;
    public float speed;

    public GameObject explosion;
    public AudioClip fire;
    public AudioClip die;

    void Start()
    {
        // to prevent staying in scene for too long if hit nothing
        Destroy(gameObject, 3.0f);
    }

    void Update()
    {
        Vector3 dir = direction * speed * Time.deltaTime;
        transform.Translate(dir);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player" || other.gameObject.tag == "Shield")
        {
            Object obj = Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(obj, 0.5f);
        }
    }
}
