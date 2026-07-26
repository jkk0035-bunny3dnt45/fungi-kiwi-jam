using UnityEngine;

public class TriggerDialogBox : MonoBehaviour
{
    public string Tag = "Player";
    [TextArea]
    public string message;

    private bool playerInTrigger = false;

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

        float baseFontSize = Mathf.Min(Screen.width, Screen.height) * 0.03f;

        GUIStyle popupStyle = new GUIStyle(GUI.skin.box);
        popupStyle.fontSize = Mathf.RoundToInt(baseFontSize);
        popupStyle.alignment = TextAnchor.MiddleCenter;
        popupStyle.wordWrap = true;
        popupStyle.normal.textColor = Color.white;

        float width = Screen.width * 0.4f;
        float height = Screen.height * 0.15f;
        float x = (Screen.width - width) * 0.5f;
        float y = Screen.height * 0.65f;

        Rect popupRect = new Rect(x, y, width, height);

        GUI.Box(popupRect, GUIContent.none, popupStyle);
        GUI.Label(popupRect, message, popupStyle);
    }
}
