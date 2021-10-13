using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenu(fileName ="New Sword Data", menuName = "Item Data/Sword")]
public class SwordData : ItemData
{
    public SwordDmgType dmgType;
    public SwordWpnType wpnType;
}
