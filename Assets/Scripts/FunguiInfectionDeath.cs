using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class FunguiInfectionDeath : MonoBehaviour
{
    public string Tag = "Player";
    public float delay = 5f;
    [TextArea]
    public string deathMessage = "You have died from fungui infection";
    public InputActionReference moveAction;
    public InputActionReference jumpAction;

    private bool showDeathMessage = false;
    private GUIStyle deathStyle;
    private bool styleInitialized;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tag))
        {
            showDeathMessage = true;

            if (moveAction != null)
                moveAction.action.Disable();
            if (jumpAction != null)
                jumpAction.action.Disable();

            Invoke(nameof(ReloadScene), delay);
        }
    }

    private void ReloadScene()
    {
        if (moveAction != null)
            moveAction.action.Enable();
        if (jumpAction != null)
            jumpAction.action.Enable();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnGUI()
    {
        if (!showDeathMessage) return;

        if (!styleInitialized)
        {
            deathStyle = new GUIStyle(GUI.skin.box);
            deathStyle.fontSize = 24;
            deathStyle.alignment = TextAnchor.MiddleCenter;
            deathStyle.wordWrap = true;
            deathStyle.normal.textColor = Color.red;
            styleInitialized = true;
        }

        float width = Screen.width * 0.6f;
        float height = 120;
        float x = (Screen.width - width) * 0.5f;
        float y = Screen.height * 0.4f;

        Rect deathRect = new Rect(x, y, width, height);

        GUI.Box(deathRect, GUIContent.none, deathStyle);
        GUI.Label(deathRect, deathMessage, deathStyle);
    }
}
