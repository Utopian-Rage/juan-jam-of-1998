using UnityEngine;
using UnityEngine.UI;
// This script adjusts the size of a Scrollbar component in Unity.
// This is useful for ensuring that the scrollbar is appropriately sized for the UI layout and correctly displays the sprite assets.
public class adjustScrollBar : MonoBehaviour
{
    void Awake()
    {
        transform.GetComponent<Scrollbar>().size = 0.1f;
    }
}
