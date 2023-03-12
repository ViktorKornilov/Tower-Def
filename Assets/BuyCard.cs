using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyCard : MonoBehaviour
{
    private Button button;

    public TowerData data;

    [Header("References")]
    [SerializeField]private TMP_Text titleText;
    [SerializeField]private TMP_Text priceText;
    [SerializeField]private Image icon;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Buy);
        
        UpdateData(data);
    }

    private void Update()
    {
        var canBuy = GameManager.instance.gold >= data.price;
        button.interactable = canBuy;
    }

    private void OnValidate() => UpdateData(data);


    void UpdateData(TowerData data)
    {
        titleText.text = data.title;
        priceText.text = data.price.ToString();
        icon.sprite = data.icon;
    }

    public void Buy()
    {
        print("$");
        GameManager.instance.gold -= data.price;
        Placer.instance.UpdateData(data);
    }
}
