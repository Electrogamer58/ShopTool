using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class ShopContainer : MonoBehaviour
{
    public List<ScriptableObject> itemList = new List<ScriptableObject>();
    public List<GameObject> itemObjectList = new List<GameObject>();
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

        foreach (var item in itemObjectList)
        {
            Debug.Log(item.ToString());
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
