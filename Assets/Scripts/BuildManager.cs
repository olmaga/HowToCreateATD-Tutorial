using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {
    public static BuildManager instance;

    public GameObject standardTurretPrefab;

    private GameObject turretToBuild;

    void Awake () {
        if (instance != null) {
            Debug.Log ("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    void Start () {
        this.turretToBuild = standardTurretPrefab;
    }

    public GameObject GetTurretToBuild () {
        return turretToBuild;
    }
}