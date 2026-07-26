using UnityEngine;
using UnityEngine.InputSystem;

public class InteractDisplay : MonoBehaviour
{
    public string Tag = "Player";
    public InputActionReference Interact;
    public GameObject destroyTarget;
    [TextArea]
    public string customMessage;
    public float popupDuration = 3f;

    private bool playerInTrigger = false;
    private Collider currentCollider;
    private bool showPopup;
    private float popupTimer;
    private string message;
    private string keyName;

    private void Start()
    {
        if (Interact != null && Interact.action != null)
        {
            var bindings = Interact.action.bindings;
            if (bindings.Count > 0)
            {
                keyName = InputControlPath.ToHumanReadableString(bindings[0].effectivePath);
            }
        }
        if (string.IsNullOrEmpty(keyName)) keyName = "?";
    }

    private void Update()
    {
        if (showPopup)
        {
            popupTimer -= Time.deltaTime;
            if (popupTimer <= 0f)
            {
                showPopup = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag)
        {
            playerInTrigger = true;
            currentCollider = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Tag)
        {
            playerInTrigger = false;
            currentCollider = null;
        }
    }

    private void OnEnable()
    {
        if (Interact != null)
            Interact.action.performed += OnInteractPerformed;
    }

    private void OnDisable()
    {
        if (Interact != null)
            Interact.action.performed -= OnInteractPerformed;
    }

    private void OnInteractPerformed(InputAction.CallbackContext ctx)
    {
        if (!playerInTrigger) return;
        if (currentCollider == null) return;

        if (destroyTarget != null)
        {
            Destroy(destroyTarget);
            destroyTarget = null;
        }

        message = !string.IsNullOrEmpty(customMessage) ? customMessage : "There is nothing here";
        showPopup = true;
        popupTimer = popupDuration;
    }

    private void OnGUI()
    {
        float baseFontSize = Mathf.Min(Screen.width, Screen.height) * 0.03f;
        float promptFontSize = Mathf.Min(Screen.width, Screen.height) * 0.025f;

        GUIStyle popupStyle = new GUIStyle(GUI.skin.box);
        popupStyle.fontSize = Mathf.RoundToInt(baseFontSize);
        popupStyle.alignment = TextAnchor.MiddleCenter;
        popupStyle.wordWrap = true;
        popupStyle.normal.textColor = Color.white;

        GUIStyle promptStyle = new GUIStyle(GUI.skin.label);
        promptStyle.fontSize = Mathf.RoundToInt(promptFontSize);
        promptStyle.alignment = TextAnchor.MiddleCenter;
        promptStyle.normal.textColor = Color.black;

        if (playerInTrigger && !showPopup)
        {
            string prompt = $"Press {keyName} to investigate";
            float promptWidth = Screen.width * 0.3f;
            float promptHeight = Screen.height * 0.05f;
            float promptX = (Screen.width - promptWidth) * 0.5f;
            float promptY = Screen.height * 0.7f;
            Rect promptRect = new Rect(promptX, promptY, promptWidth, promptHeight);
            GUI.Label(promptRect, prompt, promptStyle);
        }

        if (!showPopup) return;

        float width = Screen.width * 0.4f;
        float height = Screen.height * 0.15f;
        float x = (Screen.width - width) * 0.5f;
        float y = Screen.height * 0.35f;

        Rect popupRect = new Rect(x, y, width, height);

        GUI.Box(popupRect, GUIContent.none, popupStyle);
        GUI.Label(popupRect, message, popupStyle);
    }
}
