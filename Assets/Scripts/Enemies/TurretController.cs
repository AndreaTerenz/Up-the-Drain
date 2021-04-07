using System;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform target;
    public GatlinController leftGun;
    public GatlinController rightGun;
    public Transform gunsJoint;
    [Range(10.0f, 30.0f)]
    public float maxRange = 18.0f;
    [Range(30.0f, 90.0f)]
    public float maxAngle = 55.0f;

    private bool _active;
    private Vector3 _selfPos, _targetPos, _gunsPos;

    private void Start()
    {
        _selfPos = transform.position;
        _gunsPos = gunsJoint.position;
    }

    void Update()
    {
        _targetPos = target.position;
        _active = CheckTargetInSight();
        
        leftGun.Shoot = _active;
        rightGun.Shoot = _active;
        
        if (_active)
        {
            Vector3 trgt = new Vector3(_targetPos.x, _selfPos.y, _targetPos.z);
            transform.LookAt(trgt);
            transform.Rotate(Vector3.up, -90.0f);

            float angle = AngleToTarget();
            gunsJoint.localEulerAngles = new Vector3(0, 0, angle);
        }
    }

    public float AngleToTarget()
    {
        float dist = DistanceToTarget();
        float vDist = (_targetPos.y - _gunsPos.y);
        
        return Mathf.Rad2Deg * Mathf.Asin(vDist / dist);
    }

    public float DistanceToTarget()
    {
        return Vector3.Distance(_gunsPos, _targetPos);
    }

    public bool CheckTargetInSight()
    {
        if (Mathf.Abs(AngleToTarget()) < maxAngle && DistanceToTarget() < maxRange)
        {
            Vector3 dir = (target.position - _gunsPos).normalized;
            RaycastHit info;
            bool rayHit = Physics.Raycast(_gunsPos, dir, out info, maxRange);

            bool output = rayHit && (info.transform.CompareTag(target.tag));

            return output;
        }

        return false;
    }
}