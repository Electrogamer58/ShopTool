using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ShopDisplay : MonoBehaviour
{
    [SerializeField] private GameObject ImageObject;
    [SerializeField] private RectTransform ScrollPanel;
    [SerializeField] private Transform Viewport;
    public List<ItemData> itemsList = new List<ItemData>();
    public Text[] textToReplace;
    public Image[] imagesToReplace;

    public ShopCell[,] Grid;

    private void Awake()
    {
        Utils.Vertical = Mathf.FloorToInt(ScrollPanel.sizeDelta.y);
        Utils.Horizontal = Mathf.FloorToInt(ScrollPanel.sizeDelta.x);
        Utils.Columns = Mathf.Min(4, itemsList.Count);
        Utils.Rows = Mathf.Min(4, itemsList.Count);
        Grid = new ShopCell[Utils.Columns, Utils.Rows];

        Debug.Log(Utils.Rows);

        for (int i = 0; i < Utils.Columns; i++)
        {
            //Debug.Log("Epic");
            for (int j = 0; j < Utils.Rows; j++)
            {

                //GameObject imageObj = Instantiate(ImageObject) as GameObject;
                //GameObject imageObj = Instantiate(ImageObject, Utils.GridToWorldPosition(i, j), Quaternion.identity);

                Grid[i, j] = new ShopCell(ImageObject, Utils.Horizontal/2 + (i*300), Utils.Vertical/2* j );


                Grid[i,j].gameObject.transform.SetParent(Viewport.transform, false);



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
