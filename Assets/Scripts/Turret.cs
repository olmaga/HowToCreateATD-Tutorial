using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    [Header ("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    public float rotationSpeed = 10f;

    [Header ("Unity Setup Fields")]
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private string enemyTag = "Enemy";
    private Transform target;
    private float cooldown = 0f;

    void Start () {
        InvokeRepeating ("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);
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

        if (cooldown <= 0f) {
            Shoot ();
            cooldown = 1f / fireRate;
        }

        cooldown -= Time.deltaTime;
    }

    void Shoot () {
        GameObject bulletGO = (GameObject) Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet> ();
        if (bullet != null) {
            bullet.Seek(target);
        }
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