using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bully : MonoBehaviour
{
    [SerializeField] private Transform pizzaPosition;
    [SerializeField] private Sprite upHandsSprite;
    [SerializeField] private Sprite downHandsSprite;
    [SerializeField] private float startOfTimeRange;
    [SerializeField] private float endOfTimeRange;    
    [SerializeField] private float levelMultiplier;

    private float _coolingTime;
    
    private SpriteRenderer _spriteRenderer;

    
    

    void Start()
    {
        _coolingTime = UnityEngine.Random.Range(startOfTimeRange, endOfTimeRange);        
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(ThrowPizza());
    }
    
    private IEnumerator ThrowPizza()
    {
        while (true)
        {            
            _spriteRenderer.sprite = upHandsSprite;
            GameObject newPizza = GetNewPizza();
            yield return new WaitForSeconds(_coolingTime / levelMultiplier);
            _spriteRenderer.sprite = downHandsSprite;
            newPizza.GetComponent<Pizza>().Throw();
            yield return new WaitForSecondsRealtime(_coolingTime / levelMultiplier);            
        }
    }
    private GameObject GetNewPizza()
    {
        GameObject newPizza =  PizzaPool.Instance.GetPizzaFromPool();
        if (newPizza == null) return null;
        newPizza.transform.position = pizzaPosition.position;
        newPizza.transform.rotation = pizzaPosition.rotation;
        newPizza.SetActive(true);
        return newPizza;
    }  
}
