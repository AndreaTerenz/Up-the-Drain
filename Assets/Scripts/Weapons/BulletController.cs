using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float thrustForce = 5000;
    public float damage = 20f;
    public float range = 100f;
    
    [HideInInspector]
    public Vector3 hitPoint;
    [HideInInspector]
    public LayerMask targetsMask;
    
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
        if (!other.CompareTag("Bullet"))
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
}
