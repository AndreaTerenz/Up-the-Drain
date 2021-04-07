using UnityEngine;

public class HelpPanel : MonoBehaviour
{
    public StartMenu startMenu;
    
    public void OnEnable()
    {
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), Constants.TweenLenght);
    }

    public void OnCloseBtnClick()
    {
        LeanTween.scale(gameObject, new Vector3(1, 0, 1), Constants.TweenLenght).setOnComplete(() =>
        {
            gameObject.SetActive(false);
            startMenu.OnHelpClosed();
        });
    }

    private void Update()
    {
        if (gameObject.activeSelf && Input.GetButtonUp("Cancel"))
        {
            OnCloseBtnClick();
        }
    }
}
