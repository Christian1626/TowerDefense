using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Selectionne la tour a construire.
 **/
public class Shop : MonoBehaviour {

    BuildManager buildManager;
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncherTurret;
    public TurretBlueprint laserBeamerTurret;
    public TurretBlueprint frozenTurret;
    public TurretBlueprint lightningTurret;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret()
    {
        Debug.Log("Standart Turret Selected:" + standartTurret.cost);
        buildManager.SelectTurretToBuild(standartTurret);
    }

    public void SelectMissileTurret()
    {
        Debug.Log("Missile Turret Selected");
        buildManager.SelectTurretToBuild(missileLauncherTurret);
    }

    public void SelectLaserBeamerTurret()
    {
        Debug.Log("Laser Beamer Turret Selected");
        buildManager.SelectTurretToBuild(laserBeamerTurret);
    }

    public void SelectFrozenTurret()
    {
        Debug.Log("Frozen Turret Selected");
        buildManager.SelectTurretToBuild(frozenTurret);
    }

    public void SelectLightningTurret()
    {
        Debug.Log("Ligntning Turret Selected");
        buildManager.SelectTurretToBuild(lightningTurret);
    }
}
