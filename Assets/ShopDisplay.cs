using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEditor;

public class ShopDisplay : MonoBehaviour
{
    public ShopData shopData;
    
    [SerializeField] private RectTransform ScrollPanel;
    [SerializeField] private RectTransform ContentPanel;
    [SerializeField] private RectTransform SpawnPoint;
    public List<ItemData> itemsList = new List<ItemData>();
    public int tileSize = 5;

    private Text[] textToReplace;
    private Image[] imagesToReplace;
    private Text[] itemCosts;
    public GameObject ImageObject;

    [HideInInspector]
    public string ItemName;
    [HideInInspector]
    public int ItemCost;
    //public string ItemDesc;

    private float newPosY;
    //public int myId;

    //Shop Visuals
    private Text shopText;
    private Image shopImage;


    public ShopCell[,] Grid;

    private void Awake()
    {
        //if (shopData.autoPopulate){
        //itemsList = Load All Prefabs
        //}

        shopText = gameObject.transform.Find("Shop_txt").GetComponent<Text>();
        shopImage = GetComponent<Image>();

        if (shopText != null)
        {
            shopText.text = shopData.Name;
        }
        shopImage.color = shopData.color;
        shopImage.sprite = shopData.backgroundSprite;

        //ImageObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Item_obj.prefab", typeof(GameObject));
        

        newPosY = SpawnPoint.transform.position.y;
        int drawCount = itemsList.Count;
        

        Utils.Vertical = Mathf.FloorToInt(ScrollPanel.sizeDelta.y);
        Utils.Horizontal = Mathf.FloorToInt(ScrollPanel.sizeDelta.x);
        Utils.Columns = Mathf.Min(4, drawCount);
        Utils.Rows = Mathf.CeilToInt(drawCount/4.0f);
        Grid = new ShopCell[Utils.Rows, Utils.Columns];

       
        for (int i = 0; i < Utils.Rows; i++)
        {
            newPosY -= 300;
            for (int j = 0; j < Utils.Columns && i * Utils.Columns + j < drawCount; j++)
            {

                
                float posX = j * tileSize - 100;
                float posY = i * -tileSize + (95 * Utils.Rows);
                Grid[i, j] = new ShopCell(ImageObject, 1, (int)newPosY);
                
                Grid[i,j].gameObject.transform.SetParent(ContentPanel.transform, false);

                Grid[i, j].gameObject.transform.position = new Vector2(posX, newPosY);

                

            }
        }

        ContentPanel.sizeDelta = new Vector2(ContentPanel.sizeDelta.x, ContentPanel.sizeDelta.y * Utils.Rows);

    }


    private void Start()
    {
        

        textToReplace = FindObjectsOfType<Text>().Where(obj => obj.name == "Item_txt").ToArray<Text>();
        imagesToReplace = FindObjectsOfType<Image>().Where(obj => obj.name == "ItemImage").ToArray<Image>();
        itemCosts = FindObjectsOfType<Text>().Where(obj => obj.name == "Cost_txt").ToArray<Text>();

        for (int i = 0; i < itemsList.Count; i++)
        {

            textToReplace[i].text = itemsList[i]._name;
            imagesToReplace[i].sprite = itemsList[i].visualSprite;
            itemCosts[i].text = itemsList[i].price.ToString();

            ItemName = itemsList[i]._name;
            ItemCost = itemsList[i].price;
        }
        

    }

    public void Purchase()
    {
        Debug.Log("Purchased " + ItemName);
    }

}
