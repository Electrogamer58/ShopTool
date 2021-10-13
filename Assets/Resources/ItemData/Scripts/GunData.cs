using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenu(fileName = "New Gun Data", menuName = "Item Data/Gun")]
public class GunData : ItemData
{
    public GunDmgType dmgType;
    public GunRateType rateType;
}
