using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    [SerializeField] private Transform startPosition;

    private void OnEnable()
    {
        Bully.OnPizzaThrow += PizzaThrow;
        Bully.GetPizza += MakeNewPizza;
    }
    private void OnDisable()
    {
        Bully.OnPizzaThrow -= PizzaThrow;
        Bully.GetPizza -= MakeNewPizza;
    }

    private void PizzaThrow()
    {
        //Go pizza Go
    }
    private void MakeNewPizza()
    {
        //get new pizza from pool
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Sword"))
        {
            //return to pool
        }
        if (collision.gameObject.CompareTag("Window"))
        {
            //Brake window
            //Return to pool
        }
    }
}
