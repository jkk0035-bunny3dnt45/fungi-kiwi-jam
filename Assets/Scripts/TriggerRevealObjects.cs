using System.Collections.Generic;
using UnityEngine;

public class TriggerRevealObjects : MonoBehaviour
{
    public string Tag = "Player";
    public List<GameObject> ObjectsToReveal;

    private void Awake()
    {
        foreach (var obj in ObjectsToReveal)
        {
            if (obj == null) continue;
            var renderer = obj.GetComponent<Renderer>();
            if (renderer != null) renderer.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != Tag) return;

        foreach (var obj in ObjectsToReveal)
        {
            if (obj == null) continue;
            var renderer = obj.GetComponent<Renderer>();
            if (renderer != null) renderer.enabled = true;
        }
    }
}
