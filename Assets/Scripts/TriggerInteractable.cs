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

    private GUIStyle popupStyle;
    private GUIStyle promptStyle;
    private bool styleInitialized;

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
        if (!styleInitialized)
        {
            popupStyle = new GUIStyle(GUI.skin.box);
            popupStyle.fontSize = 18;
            popupStyle.alignment = TextAnchor.MiddleCenter;
            popupStyle.wordWrap = true;
            popupStyle.normal.textColor = Color.white;

            promptStyle = new GUIStyle(GUI.skin.label);
            promptStyle.fontSize = 16;
            promptStyle.alignment = TextAnchor.MiddleCenter;
            promptStyle.normal.textColor = Color.black;
            styleInitialized = true;
        }

        if (playerInTrigger && !showPopup)
        {
            string prompt = $"Press {keyName} to investigate";
            float promptWidth = 300;
            float promptHeight = 40;
            float promptX = (Screen.width - promptWidth) * 0.5f;
            float promptY = Screen.height * 0.7f;
            Rect promptRect = new Rect(promptX, promptY, promptWidth, promptHeight);
            GUI.Label(promptRect, prompt, promptStyle);
        }

        if (!showPopup) return;

        float width = Screen.width * 0.4f;
        float height = 100;
        float x = (Screen.width - width) * 0.5f;
        float y = Screen.height * 0.35f;

        Rect popupRect = new Rect(x, y, width, height);

        GUI.Box(popupRect, GUIContent.none, popupStyle);
        GUI.Label(popupRect, message, popupStyle);
    }
}
