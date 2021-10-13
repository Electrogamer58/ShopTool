using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenu(fileName = "New Potion Data", menuName = "Item Data/Potion")]
public class PotionData : ItemData
{
    public PotionEffectType efctType;
    public PotionSizeType sizeType;
}
