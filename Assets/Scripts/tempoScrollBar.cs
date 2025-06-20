using UnityEngine;
using UnityEngine.UI;

public class tempoScrollBar : MonoBehaviour
{
    void Awake()
    {
        transform.GetComponent<Scrollbar>().size = 0.1f;
    }
}
