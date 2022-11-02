using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPool : MonoBehaviour
{
    public static PizzaPool Instance;

    [SerializeField] private GameObject pizzaPrefab;
    [SerializeField] private int poolAmount;
    [SerializeField] private bool isExtensible;

    private List<GameObject> pizzas;
   
    private void Awake() => Instance = this;

    private void Start()
    {
        pizzas = new List<GameObject>();

        for (int i = 0; i < poolAmount; i++)
        {
            GameObject newPizza = Instantiate(pizzaPrefab);
            newPizza.SetActive(false);
            pizzas.Add(newPizza);
        }
    }

    public GameObject GetPizzaFromPool()
    {
        for(int j = 0; j < pizzas.Count; j++)
        {
            if (!pizzas[j].activeInHierarchy) return pizzas[j];
        }
        if (isExtensible)
        {
            GameObject newPizza = Instantiate(pizzaPrefab);
            return newPizza;
        }
        return null;
    }
}
