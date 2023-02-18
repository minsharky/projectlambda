using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// Used this a lot: https://www.youtube.com/watch?v=d_qk7egZ8_c
public class Tooltip : MonoBehaviour
{

    private static Tooltip instance; 
    public Camera cam;
    TMP_Text tooltipText;
    RectTransform rectTransform;

    void Start()
    {
        instance = this; 

        // imageTransform = transform.Find("Image").GetComponent<RectTransform>();
        tooltipText = transform.Find("Text").GetComponent<TMP_Text>();
        rectTransform = GetComponent<RectTransform>();
        Hide();
    }

    void Update()
    {
        // Makes the tooltip follow the mouse
        Vector2 pointOnCanvas;
        // Converts mouse position to point on UI Canvas
        // UICanvas = transform.parent
        // Mouse position = Input.mousePosition
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, cam, out pointOnCanvas);
        // Make the left bottom point of the tooltip follow the mouse
        pointOnCanvas += new Vector2(rectTransform.rect.width / 2, rectTransform.rect.height / 2);
        transform.localPosition = pointOnCanvas;
    }

    /// <summary>
    /// Enables and displays a string in the tooltip
    /// </summary>
    /// <param name="str"></param>
    private void Show(string str)
    {
        gameObject.SetActive(true);
        tooltipText.text = str;

        float padding = 4f;
        Vector2 imageSize = new Vector2(tooltipText.preferredWidth + padding*2, tooltipText.preferredHeight + padding*2);
        rectTransform.sizeDelta = imageSize;
    }

    /// <summary>
    /// Hides the tooltip
    /// </summary>
    /// <param name="str"></param>
    private void Hide()
    {
        gameObject.SetActive(false); 
    }

    public static void ShowStatic(string tooltip)
    {
        instance.Show(tooltip);
    }

    public static void HideStatic()
    {
        instance.Hide();
    }
}
