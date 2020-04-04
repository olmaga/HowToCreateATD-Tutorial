using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float panSpeed = 30f;
    public float panBoarderThickness = 10f;
    public float scrollSpeed = 250f;

    private bool doMovement = true;
    private float minY = 10f;
    private float maxY = 80f;

    void Update () {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            doMovement = !doMovement;
        }
        if (!doMovement) {
            return;
        }
        Move ();
        Zoom ();
    }

    private void Move () {
        if (Input.GetKey ("w") || Input.mousePosition.y > Screen.height - panBoarderThickness) {
            transform.Translate (Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey ("s") || Input.mousePosition.y < panBoarderThickness) {
            transform.Translate (Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey ("a") || Input.mousePosition.x < panBoarderThickness) {
            transform.Translate (Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey ("d") || Input.mousePosition.x > Screen.width - panBoarderThickness) {
            transform.Translate (Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
    }

    private void Zoom () {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 position = transform.position;

        position.y -= scroll * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);

        transform.position = position;
    }
}