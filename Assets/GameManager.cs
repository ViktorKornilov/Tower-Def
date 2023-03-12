using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gold;
    [SerializeField] private TMP_Text goldText;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        InvokeRepeating("AutoGold",1,1);
    }

    private void Update()
    {
        goldText.text = gold.ToString();
    }

    void AutoGold()
    {
        gold+=10;
    }
}
