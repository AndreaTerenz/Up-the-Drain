using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameManager gm;
    public Collider groundCollider;
    private float startY;

    private int gianni = 0;
    private GameObject lastPlatform = null;

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
        else
        {
            GameObject otherObj = other.gameObject;
            
            if (otherObj.CompareTag("Platform") && otherObj != lastPlatform)
            {
                lastPlatform = otherObj;
                int lvl = otherObj.GetComponentInParent<Platform>().levelID;
                
                Debug.Log(lvl);
                gm.UpdateLevelsInHUD(lvl);
            }
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(0, startY, 0);
    }
}
