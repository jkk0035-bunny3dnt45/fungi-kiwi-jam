using UnityEngine;

public class TriggerDialogBox : MonoBehaviour
{
    public string Tag = "Player";
    [TextArea]
    public string message;

    private bool playerInTrigger = false;
    private GUIStyle popupStyle;
    private bool styleInitialized;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag)
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Tag)
        {
            playerInTrigger = false;
        }
    }

    private void OnGUI()
    {
        if (!playerInTrigger) return;

        if (!styleInitialized)
        {
            popupStyle = new GUIStyle(GUI.skin.box);
            popupStyle.fontSize = 18;
            popupStyle.alignment = TextAnchor.MiddleCenter;
            popupStyle.wordWrap = true;
            popupStyle.normal.textColor = Color.white;
            styleInitialized = true;
        }

        float width = Screen.width * 0.4f;
        float height = 100;
        float x = (Screen.width - width) * 0.5f;
        float y = Screen.height * 0.65f;

        Rect popupRect = new Rect(x, y, width, height);

        GUI.Box(popupRect, GUIContent.none, popupStyle);
        GUI.Label(popupRect, message, popupStyle);
    }
}
