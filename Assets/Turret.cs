using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public float range = 15f;
    public Transform partToRotate;

    private Transform target;
    private float rotationSpeed = 10f;

    void Start () {
        InvokeRepeating ("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) {
            target = nearestEnemy.transform;
        } else {
            target = null;
        }
    }

    void Update () {
        if (target == null) {
            return;
        }

        RotateToTarget ();
    }

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, range);
    }

    private void RotateToTarget () {
        Vector3 directionToTarget = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation (directionToTarget);
        Vector3 rotation = Quaternion.Lerp (partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);
    }
}