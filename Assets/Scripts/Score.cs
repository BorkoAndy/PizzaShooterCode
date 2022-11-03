using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int value;
    [SerializeField] private int valueToUpgradeLevel;

    private int score;

    public static Action OnLevelUpgrade;

    private void OnEnable() => Pizza.OnPizzaCatch += ScoreUpdate;
    private void OnDisable() => Pizza.OnPizzaCatch -= ScoreUpdate;
    private void Start() => score = 0;
    private void ScoreUpdate()
    {
        score += value;
        scoreText.text = "Score " + score;
        if (score >= valueToUpgradeLevel)
            OnLevelUpgrade?.Invoke();
    }
}
