using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncherTurret;
    public TurretBlueprint laserBeamerTurret;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret()
    {
        Debug.Log("Standart Turred Selected");
        buildManager.SelectTurretToBuild(standartTurret);
    }

    public void SelecteMissileTurret()
    {
        Debug.Log("Missile Turred Selected");
        buildManager.SelectTurretToBuild(missileLauncherTurret);
    }

    public void SelecteLaserBeamerTurret()
    {
        Debug.Log("Laser Beamer Selected");
        buildManager.SelectTurretToBuild(laserBeamerTurret);
    }
}
