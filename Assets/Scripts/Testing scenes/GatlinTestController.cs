using UnityEngine;

public class GatlinTestController : MonoBehaviour
{
    public GatlinController gun;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gun.Shoot = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gun.Shoot = false;
        }
    }
}
