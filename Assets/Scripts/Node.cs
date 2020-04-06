using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {
    public Color hoverColor;
    public Vector3 positionOffset;

    [Header ("Optional")]
    public GameObject turret;

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
        if (!buildManager.CanBuild) {
            return;
        }
        if (turret != null) {
            Debug.Log ("Can't build here!");
            return;
        }

        buildManager.BuildTurretOn (this);
    }

    void OnMouseEnter () {
        if (EventSystem.current.IsPointerOverGameObject ()) {
            return;
        }
        if (!buildManager.CanBuild) {
            return;
        }

        nodeRenderer.material.color = hoverColor;
    }

    void OnMouseExit () {
        nodeRenderer.material.color = defaultColor;
    }

    public Vector3 GetBuildPosition () {
        return this.transform.position + this.positionOffset;
    }
}