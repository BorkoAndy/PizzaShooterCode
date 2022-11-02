using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float throwingRange;

    private Rigidbody2D _rigidbody;
    public bool go;
   
    private void Start() => _rigidbody = GetComponent<Rigidbody2D>();

    public void Throw()
    {
        float randomX = UnityEngine.Random.Range(-throwingRange, throwingRange);
        _rigidbody.velocity = new Vector3(randomX, -speed, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Sword"))
        {
            gameObject.SetActive(false);
            //Score increase
        }
        if (collision.gameObject.CompareTag("Window"))
        {
            //Brake window
            gameObject.SetActive(false);
        }
    }
}
