using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMiniMenu : MonoBehaviour
{
    public GameObject miniMenu;
    public ShopDisplay shopDisplay;

    public string myName;
    public string myCost;

    public Text cost;
    private string desc;

    private void Awake()
    {
        miniMenu = GameObject.Find("MiniMenu");
        shopDisplay = FindObjectOfType<ShopDisplay>();
        cost = miniMenu.gameObject.transform.Find("cost_txt").GetComponent<Text>();
        desc = miniMenu.gameObject.transform.Find("desc_txt").GetComponent<Text>().text;
        
    }


    public void UpdateMenu()
    {
        
        myCost = this.gameObject.transform.Find("Cost_txt").GetComponent<Text>().text;
        cost.text = "Cost: " + myCost;
        myName = this.gameObject.transform.Find("Item_txt").GetComponent<Text>().text;
        shopDisplay.ItemName = myName;
        //shopDisplay.myId = shopDisplay.itemsList


    }

}
