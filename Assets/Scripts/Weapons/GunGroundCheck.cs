using UnityEngine;

public class GunGroundCheck : MonoBehaviour
{
    public MeshCollider bodyCollider;
    public bool startsDropped = false;
    
    public bool dropped
    {
        get => ReferenceEquals(parentTransform, null);
        set
        {
            bodyCollider.enabled = value;
            _rb.isKinematic = !value;
            _rb.useGravity = value;

            if (value)
            {
                if (applyDropForce)
                {
                    _rb.AddForce((_tr.up + _tr.forward).normalized * 200f);
                    _rb.AddTorque(_tr.up * 50f);
                }
                else
                {
                    //if it's false, it means that the weapon was spawned "in the air"
                    //and should therefore simply fall to the ground
                    applyDropForce = true;
                }
            }
            else
            {
                _rb.velocity *= 0;
                _rb.angularVelocity *= 0;
            }
        }
    }

    public Transform parentTransform
    {
        get => _tr.parent;
        set
        {
            _tr.SetParent(value);

            dropped = ReferenceEquals(value, null);
            
            if (!dropped)
            {
                _tr.localPosition = Vector3.zero;
                _tr.localRotation = Quaternion.identity;
            }
        }
    }

    private bool applyDropForce;
    private Transform _tr;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _tr = transform;

        startsDropped = startsDropped || ReferenceEquals(parentTransform, null);
        
        applyDropForce = !startsDropped;
        dropped = startsDropped;
        Debug.Log(dropped);
    }
}
