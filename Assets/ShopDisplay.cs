using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ShopDisplay : MonoBehaviour
{
    [SerializeField] private GameObject ImageObject;
    [SerializeField] private RectTransform ScrollPanel;
    public List<ItemData> itemsList = new List<ItemData>();
    public Text[] textToReplace;
    public Image[] imagesToReplace;

    public ShopCell[,] Grid;

    public Transform ScrollViewGameObject;

    private void Awake()
    {
        Utils.Vertical = Mathf.FloorToInt(ScrollPanel.sizeDelta.y);
        Utils.Horizontal = Mathf.FloorToInt(ScrollPanel.sizeDelta.x);
        Utils.Columns = Utils.Horizontal * 2;
        Utils.Rows = Utils.Vertical * 2;
        Grid = new ShopCell[Utils.Columns, Utils.Rows];

        Debug.Log(Utils.Columns);

        for (int i = 0; i < Utils.Columns; i++)
        {
            for (int j = 0; j < Utils.Rows; j++)
            {

                //GameObject imageObj = Instantiate(ImageObject) as GameObject;
                //GameObject imageObj = Instantiate(ImageObject, Utils.GridToWorldPosition(i, j), Quaternion.identity);
                Debug.Log("Epic");
                if (ScrollViewGameObject != null)
                {
                    Grid[i, j] = new ShopCell(ImageObject, i, j);


                    //imageObj.transform.SetParent(ScrollViewGameObject, false);

                }

            }
        }

    }


    private void Start()
    {
        //if (autoPopulate){
        //itemsList = Load All scriptableObjects
        //}

        textToReplace = FindObjectsOfType<Text>().Where(obj => obj.name == "Item_txt").ToArray<Text>();
        imagesToReplace = FindObjectsOfType<Image>().Where(obj => obj.name == "ItemImage").ToArray<Image>();

         for (int i = 0; i < itemsList.Count; i++)
        {

            Debug.Log(itemsList[i]);
            Debug.Log(imagesToReplace[i]);
            textToReplace[i].text = itemsList[i]._name;
            imagesToReplace[i].sprite = itemsList[i].visualSprite;
        }
        

    }

}
