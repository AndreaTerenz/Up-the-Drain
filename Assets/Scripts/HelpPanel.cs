using UnityEngine;

public class HelpPanel : MonoBehaviour
{
    public void OnCloseBtnClick()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (gameObject.activeSelf && Input.GetButtonUp("Cancel"))
        {
            OnCloseBtnClick();
        }
    }
}
