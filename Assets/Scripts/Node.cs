using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;
    private Renderer nodeRenderer;
    private Color defaultColor;

    void Start () {
        nodeRenderer = GetComponent<Renderer> ();
        defaultColor = nodeRenderer.material.color;
    }
    void OnMouseDown () {
        if (turret != null) {
            Debug.Log ("Can't build here!");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter () {
        nodeRenderer.material.color = hoverColor;
    }

    void OnMouseExit () {
        nodeRenderer.material.color = defaultColor;
    }
}