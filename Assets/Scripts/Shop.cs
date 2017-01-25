using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandartTurret()
    {
        Debug.Log("Standart Turred Selected");
        buildManager.SetTurretToBuild(buildManager.standartTurretPrefab);
    }

    public void PurchaseMissileTurret()
    {
        Debug.Log("Missile Turred Selected");
        buildManager.SetTurretToBuild(buildManager.missileTurretPrefab);
    }
}
