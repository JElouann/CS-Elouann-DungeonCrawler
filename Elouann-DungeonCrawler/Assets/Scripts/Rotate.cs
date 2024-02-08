using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    private Camera mainCamera;
    private Vector3 mousePos;
    private GameObject gunChild;
    private SpriteRenderer gunChildSprite;
    
    // Start is called before the first frame update
    private void Start()
    {
        mainCamera = Camera.main;
        gunChild = this.transform.GetChild(0).gameObject;
        gunChildSprite = gunChild.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg; // Permet de récupérer la rotation en Z de l'objet

        if (rotZ > 90 | rotZ < -90) // à transformer en event, potentiellement
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

    public float ReturnRotZ(float rotZ)
    {
        return rotZ;
    }
}
