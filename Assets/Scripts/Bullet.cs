using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 70f;
    public GameObject impactEffect;

    private Transform target;

    public void Seek (Transform newTarget) {
        this.target = newTarget;
    }

    void Update () {
        // e.g. target got killed already or reached goal
        if (target == null) {
            Destroy (gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) {
            HitTarget ();
            return;
        }
        transform.Translate (dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget () {
        GameObject effect = Instantiate (impactEffect, transform.position, transform.rotation);
        Destroy (effect, 2f);
        Destroy (target.gameObject);
        Destroy (gameObject);
    }
}