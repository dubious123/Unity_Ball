using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Progress 
{
    public Progress()
    {
        World = 1;
        Map = 1;
    }
    public int World;
    public int Map;
}
