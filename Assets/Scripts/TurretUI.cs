﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour {
	private Node target;
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public void SetTarget(Node node) {
		target = node;

		transform.position = target.GetBuildPosition();

        upgradeCost.text = "$"+target.turretBlueprint.upgradeCost;

        if(!target.isUpgraded) {
            upgradeButton.interactable = true;
        } else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }
        Show();
    }
   
    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Show()
    {
        ui.SetActive(true);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
