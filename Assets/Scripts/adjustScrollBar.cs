using UnityEngine;
using UnityEngine.UI;

public class adjustScrollBar : MonoBehaviour
{
    void Awake()
    {
        transform.GetComponent<Scrollbar>().size = 0.1f;
    }
}
