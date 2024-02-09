using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    private GameObject gunChild;
    private SpriteRenderer gunChildSprite;

    public float ReturnRotZ(float rotZ)
    {
        return rotZ;
    }

    private void Start()
    {
        mainCamera = Camera.main;
        gunChild = this.transform.GetChild(0).gameObject;
        gunChildSprite = gunChild.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg; // Permet de récupérer la rotation en Z de l'objet
        // à transformer en event, potentiellement
        if (rotZ > 90 | rotZ < -90)
        {
            gunChildSprite.flipY = true;
        }
        else
        {
            gunChildSprite.flipY = false;
        }

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        ReturnRotZ(rotZ);
    }
}
