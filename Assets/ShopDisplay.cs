using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ShopDisplay : MonoBehaviour
{
    [SerializeField] private GameObject ImageObject;
    public List<ItemData> itemsList = new List<ItemData>();
    public Text[] textToReplace;
    public Image[] imagesToReplace;

    public Transform ScrollViewGameObject;

    private void Awake()
    {
        for (int i = 0; i < itemsList.Count; i++)
        {
            GameObject imageObj = Instantiate(ImageObject) as GameObject;

            if (ScrollViewGameObject != null)
            {
                imageObj.transform.SetParent(ScrollViewGameObject, false);

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
