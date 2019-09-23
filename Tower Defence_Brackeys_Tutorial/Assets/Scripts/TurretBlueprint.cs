﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint 
{
    public GameObject turret;
    public int cost;

    public GameObject upgradedTurret;
    public int upgradeCost;

    public int SellingPrice()
    {
        return cost / 2;
    }
}
