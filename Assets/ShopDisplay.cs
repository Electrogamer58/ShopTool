﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ShopDisplay : MonoBehaviour
{
    public ShopData shopData;
    [SerializeField] private GameObject ImageObject;
    [SerializeField] private RectTransform ScrollPanel;
    [SerializeField] private RectTransform ContentPanel;
    [SerializeField] private RectTransform SpawnPoint;
    [SerializeField] private Transform WhereToPlaceItems;
    public List<ItemData> itemsList = new List<ItemData>();
    public Text[] textToReplace;
    public Image[] imagesToReplace;
    public int tileSize = 5;

    private float newPosY;

    public ShopCell[,] Grid;

    private void Awake()
    {
        //if (autoPopulate){
        //itemsList = Load All scriptableObjects
        //}
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
                Grid[i, j] = new ShopCell(ImageObject, 1, (int)newPosY );
                Grid[i,j].gameObject.transform.SetParent(WhereToPlaceItems.transform, false);

                Grid[i, j].gameObject.transform.position = new Vector2(posX, newPosY);



            }
        }

        ContentPanel.sizeDelta = new Vector2(ContentPanel.sizeDelta.x, ContentPanel.sizeDelta.y * Utils.Rows);

    }


    private void Start()
    {
        

        textToReplace = FindObjectsOfType<Text>().Where(obj => obj.name == "Item_txt").ToArray<Text>();
        imagesToReplace = FindObjectsOfType<Image>().Where(obj => obj.name == "ItemImage").ToArray<Image>();

         for (int i = 0; i < itemsList.Count; i++)
        {

            textToReplace[i].text = itemsList[i]._name;
            imagesToReplace[i].sprite = itemsList[i].visualSprite;
        }
        

    }

}
