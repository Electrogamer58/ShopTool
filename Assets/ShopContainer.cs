using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEngine.UI;

public class ShopContainer : MonoBehaviour
{
    [SerializeField] private GameObject ImageObject;

    public List<ScriptableObject> itemList = new List<ScriptableObject>();
    public List<GameObject> itemObjectList = new List<GameObject>();
    public List<Sprite> itemSpriteList = new List<Sprite>();
    public static int numSpawned = 0;
    public static Object[] subListPrefabs;
    private Vector3 startPosition;

    void Start()
    {
        Object[] subListObjects = Resources.LoadAll("ItemData/Data", typeof(ScriptableObject));

        foreach (ScriptableObject subListObject in subListObjects)
        {
            ScriptableObject lo = (ScriptableObject)subListObject;
            
            Debug.Log(lo);

        }

        foreach (GameObject item in itemObjectList)
        {
            //GameObject shopItem = Instantiate(item, item.transform.parent, false) as GameObject;

            Debug.Log(item.ToString());
        }

        foreach (Sprite image in itemSpriteList)
        {
            //Sprite spriteImage = itemSpriteList;
            //GameObject imageObj = Instantiate(ImageObject, ImageObject.transform.parent, false);
            //imageObj.GetComponent<Image>().sprite = image;
            Debug.Log(image.ToString());
        }

        // Concatenate all items into a single string
        // NOTE:  If the List is long, this would be more efficient with a
        // StringBuilder
        string result = "List contents: ";
        foreach (var item in itemObjectList)
        {
            result += item.ToString() + ", ";
        }
        Debug.Log(result);

        startPosition = transform.position;
       
    }
}
