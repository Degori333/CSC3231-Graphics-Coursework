using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject rotateAround;
    public float orbitingSpeed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Orbiting();
        selfRotate();
    }

    void Orbiting()
    {
        transform.RotateAround(rotateAround.transform.position, Vector3.up, orbitingSpeed * Time.deltaTime);
    }

    void selfRotate()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
