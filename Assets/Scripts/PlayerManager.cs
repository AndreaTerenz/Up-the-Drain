using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameManager gm;
    public Collider groundCollider;
    public FirstPersonLook playerLook;
    
    private float startY;
    private GameObject lastPlatform;

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
                
                gm.UpdateLevelsInHUD(lvl);
            }
        }
    }

    public void SetPaused(bool p)
    {
        playerLook.enabled = p;
    }

    public void Reset()
    {
        transform.position = new Vector3(0, startY, 0);
    }
}
