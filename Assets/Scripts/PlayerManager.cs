using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameManager gm;
    public Collider groundCollider;
    private float startY;
    
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider == groundCollider)
        {
            Debug.Log("DED");
            Reset();
            gm.ResetGame();
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(0, startY, 0);
    }
}
