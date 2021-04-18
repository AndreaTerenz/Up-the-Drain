using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float maxGroundDistance = .3f;
    public bool isGrounded;


    void LateUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, maxGroundDistance);
    }

    void OnDrawGizmosSelected()
    {
        Vector3 trPos = transform.position;
        RaycastHit hit;
        if (Physics.Raycast(trPos, Vector3.down, out hit, maxGroundDistance))
            Debug.DrawLine(trPos, hit.point, Color.white);
        else
            Debug.DrawLine(trPos, trPos + Vector3.down * maxGroundDistance, Color.red);
    }


    public static GroundCheck Create(Transform parent)
    {
        GameObject newGroundCheck = new GameObject("Ground check");
#if UNITY_EDITOR
        UnityEditor.Undo.RegisterCreatedObjectUndo(newGroundCheck, "Created ground check");
#endif
        newGroundCheck.transform.parent = parent;
        newGroundCheck.transform.localPosition = Vector3.up * .01f;
        return newGroundCheck.AddComponent<GroundCheck>();
    }
}
