using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Text CountOfMoneyS;
    [SerializeField] private UnityEngine.UI.Text CountOfMoneyB;
    [SerializeField] private UnityEngine.UI.Text CountOfTomats;
    [SerializeField] private UnityEngine.UI.Text CountOfMoneyForTomats;
    private void Update()
    {
        ShopInventory ShopInventoryScript = GameObject.Find("ShopInventory").GetComponent<ShopInventory>();
        if (CountOfMoneyS != null) CountOfMoneyS.text = "� ��� �� ����� " + ShopInventoryScript.money + " �����";
        if (CountOfMoneyB != null) CountOfMoneyB.text = "� ��� �� ����� " + ShopInventoryScript.money + " �����";
        if (CountOfTomats != null) CountOfTomats.text = ShopInventoryScript.tomat + " ��������";
        if (CountOfMoneyForTomats != null) CountOfMoneyForTomats.text = ShopInventoryScript.tomat * 5 + " �����";
    }
    public void SellTomat()
    {
        ShopInventory ShopInventoryScript = GameObject.Find("ShopInventory").GetComponent<ShopInventory>();
        ShopInventoryScript.money += ShopInventoryScript.tomat * 5;
        ShopInventoryScript.tomat = 0;
    }
    public void BuySeeds()
    {
        ShopInventory ShopInventoryScript = GameObject.Find("ShopInventory").GetComponent<ShopInventory>();
        if (ShopInventoryScript.money >= 5) ShopInventoryScript.money -= 5;
    }
    public void BuyShovel()
    {
        ShopInventory ShopInventoryScript = GameObject.Find("ShopInventory").GetComponent<ShopInventory>();
        if (ShopInventoryScript.money >= 20) ShopInventoryScript.money -= 20;

    }
}
