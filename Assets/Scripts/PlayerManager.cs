using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameManager gm;
    public Collider groundCollider;
    private float startY;

    private int gianni = 0;
    private GameObject uau = null;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider == groundCollider)
        {
            Reset();
            gm.ResetGame();
        }
        else if (other.gameObject.CompareTag("Platform") && other.gameObject != uau)
        {
            uau = other.gameObject;
            gianni += 1;
            
            Debug.Log(gianni);
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(0, startY, 0);
    }
}
