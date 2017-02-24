using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject towerInfo;
    public Text name;
    public Text cost;
    public Text range;
    public Text abilities;
    public Text strong;
    public Text weak;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    ///==================================
    /// MOUSE ONCLICK
    /// =================================

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

    ///==================================
    /// MOUSE HOVER
    /// =================================

    public void MouseHoverStandartTurret()
    {
        Debug.Log("Standart Turret MouseHover:" + standartTurret.cost);
        SetTowerInfoData(standartTurret);
    }

    public void MouseHoverMissileTurret()
    {
        Debug.Log("Missile Turret MouseHover");
        SetTowerInfoData(missileLauncherTurret);
    }

    public void MouseHoverLaserBeamerTurret()
    {
        Debug.Log("Laser Beamer Turret MouseHover");
        SetTowerInfoData(laserBeamerTurret);
    }

    public void MouseHoverFrozenTurret()
    {
        Debug.Log("Frozen Turret MouseHover");
        SetTowerInfoData(frozenTurret);
    }

    public void MouseHoverLightningTurret()
    {
        Debug.Log("Ligntning Turret MouseHover");
        SetTowerInfoData(lightningTurret);
    }

    void SetTowerInfoData(TurretBlueprint tower)
    {
        towerInfo.SetActive(true);
        //Get Tower
        name.text = "tower.name";
        cost.text = tower.cost.ToString();
        range.text = "tower.range";
        abilities.text = "tower.abilities";
        strong.text = "tower.strong";
        weak.text = "tower.weak";
    }

    public void MouseHoverExit()
    {
        Debug.Log("MOUSE EXIT");
        towerInfo.SetActive(false);
    }
}
