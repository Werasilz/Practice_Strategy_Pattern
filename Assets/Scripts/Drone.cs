using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    // Ray parameter
    private RaycastHit _hit;
    private Vector3 _rayDirection;
    private float _rayAngle = -45.0f;
    private float _rayDistance = 15.0f;

    // Movement parameters
    public float speed = 1f;
    public float maxHeigh = 5f;
    public float weavingDistance = 1.5f;
    public float fallbackDistance = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rayDirection = transform.TransformDirection(Vector3.back) * _rayDistance;

        _rayDirection = Quaternion.Euler(_rayAngle, 0f, 0f) * _rayDirection;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, _rayDirection, Color.blue);

        if (Physics.Raycast(transform.position, _rayDirection, out _hit, _rayDistance))
        {
            if (_hit.collider)
            {
                Debug.DrawRay(transform.position, _rayDirection, Color.green);
            }
        }
    }

    public void ApplyStrategy(IManeuverBehaviour strategy)
    {
        strategy.Maneuver(this);
    }
}
