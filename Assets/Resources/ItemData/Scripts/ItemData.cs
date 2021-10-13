using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{
    public GameObject prefab;
    public Sprite visualSprite;
    public float price; //how expensive it is
    public bool canBreak;
    public float maxHealth; //how much health it has if it can break
    public float maxCharge; //cooldown charge
    public float critChance; //chance for critical hit or heal
    public float power; //this is damage, health recovered, or a number needed to calculate a change in game
    public string _name; //name of item
}
