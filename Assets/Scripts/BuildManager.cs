using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {
    private GameObject turretToBuild;

    public static BuildManager instance;

    public GameObject standartTurretPrefab;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }
        instance = this;
    }

    void Start()
    {
        turretToBuild = standartTurretPrefab;
    }


    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

}
