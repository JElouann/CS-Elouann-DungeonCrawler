using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector3 _mousePos;
    private GameObject _gunChild;
    private SpriteRenderer _gunChildSprite;

    public float ReturnRotZ(float rotZ)
    {
        return rotZ;
    }

    private void Start()
    {
        _mainCamera = Camera.main;
        _gunChild = this.transform.GetChild(0).gameObject;
        _gunChildSprite = _gunChild.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = _mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg; // Permet de récupérer la rotation en Z de l'objet
        // à transformer en event, potentiellement
        if (rotZ > 90 | rotZ < -90)
        {
            _gunChildSprite.flipY = true;
        }
        else
        {
            _gunChildSprite.flipY = false;
        }

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        ReturnRotZ(rotZ);

    }
}
