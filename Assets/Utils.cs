using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static int Vertical, Horizontal, Columns, Rows;

    public static Vector3 GridToWorldPosition(int x, int y)
    {
        return new Vector3(x - (Horizontal - 0.5f), y - (Vertical - 0.5f));
    }


}
