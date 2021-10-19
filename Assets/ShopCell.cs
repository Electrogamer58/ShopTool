using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ShopCell
{
    public GameObject gameObject;
    public SpriteRenderer renderer;
    public int x;
    public int y;

    public ShopCell(GameObject prefab, int _x, int _y)
    {
        x = _x;
        y = _y;
        gameObject = GameObject.Instantiate(prefab, Utils.GridToWorldPosition(_x, _y), Quaternion.identity);
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        gameObject.name = "X: " + x + "Y: " + y;
        //renderer.sprite = sprite;
    }

    public void UpdateTile(Sprite sprite)
    {
        renderer.sprite = sprite;
    }
}
