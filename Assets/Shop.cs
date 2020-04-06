using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {
    BuildManager buildManager;
    public TurretBluePrint standardTurret;
    public TurretBluePrint missileLauncher;

    void Start() {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret () {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher () {
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}