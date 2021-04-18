using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float thrustForce;
    public float damage = 20f;
    public LayerMask targetsMask;
    public float range = 100f;
    [HideInInspector]
    public Vector3 hitPoint;
    
    private Vector3 _start;

    private void Start()
    {
        _start = transform.position;
        GetComponent<Rigidbody>().AddForce((hitPoint - _start).normalized * thrustForce);
    }

    private void Update()
    {
        if (Vector3.Distance(_start, transform.position) > range)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (targetsMask == (targetsMask | (1 << other.gameObject.layer)))
        {
            if (other.gameObject.TryGetComponent(out HealthManager hm))
            {
                hm.currentHealth -= damage;
            }
        }
        
        Destroy(gameObject);
    }
}
