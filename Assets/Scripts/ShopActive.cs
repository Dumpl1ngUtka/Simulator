using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopActive : MonoBehaviour
{
    [SerializeField] private GameObject SellDisplay;
    [SerializeField] private GameObject BuyDisplay;
    private void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player"))
        {
            return;
        }
        SellDisplay.SetActive(true);
        BuyDisplay.SetActive(true);
    }
    private void OnTriggerExit(Collider col)
    {
        if (!col.CompareTag("Player"))
        {
            return;
        }
        SellDisplay.SetActive(false);
        BuyDisplay.SetActive(false);
    }
    private void Start()
    {
        SellDisplay.SetActive(false);
        BuyDisplay.SetActive(false);
    }
}
