using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bully : MonoBehaviour
{
    [SerializeField] private Sprite upHandsSprite;
    [SerializeField] private Sprite downHandsSprite;
    [SerializeField] private float startOfTimeRange;
    [SerializeField] private float endOfTimeRange;

    private float levelMultiplier;
    private float _coolingTime;
    private SpriteRenderer _spriteRenderer;

    public static Action OnPizzaThrow, GetPizza;    

    void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();        
        StartCoroutine(ThrowPizza());
        levelMultiplier = 1;
    }    
    
    private  IEnumerator ThrowPizza()
    {
        while (true)
        { 
            _coolingTime = UnityEngine.Random.Range(startOfTimeRange, endOfTimeRange);
            _spriteRenderer.sprite = upHandsSprite;
            yield return new WaitForSecondsRealtime(_coolingTime / levelMultiplier);
            _spriteRenderer.sprite = downHandsSprite;
            OnPizzaThrow?.Invoke();
            yield return new WaitForSecondsRealtime(_coolingTime / levelMultiplier);
            GetPizza?.Invoke();
        }       
    }   
}
