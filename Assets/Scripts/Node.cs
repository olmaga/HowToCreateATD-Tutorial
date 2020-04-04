using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;
    private Renderer nodeRenderer;
    private Color defaultColor;
    BuildManager buildManager;

    void Start () {
        nodeRenderer = GetComponent<Renderer> ();
        defaultColor = nodeRenderer.material.color;
        buildManager = BuildManager.instance;
    }
    void OnMouseDown () {
        if (EventSystem.current.IsPointerOverGameObject ()) {
            return;
        }
        if (buildManager.GetTurretToBuild () == null) {
            Debug.Log ("No turret selected in Shop");
            return;
        }
        if (turret != null) {
            Debug.Log ("Can't build here!");
            return;
        }
        
        GameObject turretToBuild = buildManager.GetTurretToBuild ();
        turret = (GameObject) Instantiate (turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter () {
        if (EventSystem.current.IsPointerOverGameObject ()) {
            return;
        }
        if (buildManager.GetTurretToBuild () == null) {
            return;
        }

        nodeRenderer.material.color = hoverColor;
    }

    void OnMouseExit () {
        nodeRenderer.material.color = defaultColor;
    }
}