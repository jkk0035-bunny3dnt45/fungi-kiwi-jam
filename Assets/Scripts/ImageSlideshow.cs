using UnityEngine;
using UnityEngine.UI;

public class ImageSlideshow : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    [SerializeField] private float switchInterval = 3f;

    private Image imageComponent;
    private int currentIndex = 0;
    private float timer = 0f;
    private bool isPlaying = false;
    private bool hasTriggered = false;
    private BoxCollider triggerCollider;

    private void Start()
    {
        triggerCollider = GetComponentInChildren<BoxCollider>();

        if (triggerCollider == null)
        {
            Debug.LogWarning("No BoxCollider found in children");
            Destroy(this);
            return;
        }

        triggerCollider.isTrigger = true;

        if (images.Length == 0)
        {
            Debug.LogWarning("No images assigned to slideshow");
            Destroy(this);
            return;
        }

        GameObject canvasGO = new GameObject("SlideshowCanvas");
        canvasGO.transform.SetParent(transform);
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 999;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        GameObject imageGO = new GameObject("SlideshowImage");
        imageGO.transform.SetParent(canvasGO.transform, false);
        imageComponent = imageGO.AddComponent<Image>();
        imageComponent.rectTransform.anchorMin = Vector2.zero;
        imageComponent.rectTransform.anchorMax = Vector2.one;
        imageComponent.rectTransform.offsetMin = Vector2.zero;
        imageComponent.rectTransform.offsetMax = Vector2.zero;
        imageComponent.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;
        if (!other.CompareTag("Player")) return;

        hasTriggered = true;
        isPlaying = true;
        imageComponent.enabled = true;
        imageComponent.sprite = images[currentIndex];
    }

    private void Update()
    {
        if (!isPlaying) return;

        timer += Time.deltaTime;

        if (timer >= switchInterval)
        {
            timer = 0f;
            currentIndex++;

            if (currentIndex >= images.Length)
            {
                Destroy(imageComponent.gameObject);
                Destroy(this);
                return;
            }

            imageComponent.sprite = images[currentIndex];
        }
    }
}
