using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {
    BuildManager buildManager;

    void Start() {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret () {
        Debug.Log ("Standard Selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseAnotherTurred () {
        Debug.Log ("Another Selected");
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }
}