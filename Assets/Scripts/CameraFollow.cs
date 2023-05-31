using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform Hero;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Hero.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = Hero.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
