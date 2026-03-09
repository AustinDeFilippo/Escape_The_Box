using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    public int buttonIndex;
    public Color normalColor;
    public Color flashColor;
    public Image buttonImage;

    private void Start()
    {
        buttonImage = GetComponentInChildren<Image>();

        if (buttonImage != null)
        {
            buttonImage.color = normalColor;
        }
        else
        {
            Debug.LogError("No Image component found in " + gameObject.name);
        }
    }

    public void OnClick()
    {
        GameManager.Instance.PlayerPressed(buttonIndex);
    }

    public void Flash()
    {
        StartCoroutine(FlashRoutine());
    }

    private System.Collections.IEnumerator FlashRoutine()
    {
        buttonImage.color = flashColor;
        yield return new WaitForSeconds(0.5f);
        buttonImage.color = normalColor;
    }
}
