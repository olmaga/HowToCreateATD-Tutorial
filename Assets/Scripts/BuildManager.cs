using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {
    public static BuildManager instance;

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    private TurretBluePrint turretToBuild;

    void Awake () {
        if (instance != null) {
            Debug.Log ("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn (Node node) {
        if (PlayerStats.Money < turretToBuild.cost) {
            return;
            Debug.Log ("Money needed");
        }

        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject) Instantiate (turretToBuild.prefab, node.GetBuildPosition (), Quaternion.identity);
        node.turret = turret;

        Debug.Log ("Turret built! Money left: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild (TurretBluePrint turret) {
        turretToBuild = turret;
    }
}