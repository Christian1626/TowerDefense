using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfoUI : MonoBehaviour {
    public Text name;
    public Text cost;
    public Text range;
    public Text abilities;
    public Text strong;
    public Text weak;

    void onSelectedTower()
    {
        enabled = true;
        //Get Tower
        name.text = "tower.name";
        cost.text = "tower.cost";
        range.text = "tower.range";
        abilities.text = "tower.abilities";
        strong.text = "tower.strong";
        weak.text = "tower.weak";
    }
}
