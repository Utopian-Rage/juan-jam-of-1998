using UnityEngine;
public class pylonBehaviour : MonoBehaviour
{
    [SerializeField] float interval = 3f;
    [SerializeField] GameObject LightObject;
    private bool isPylonOn = false;
    private float timer = 0f;
    Collider2D pylonCollider;
    void Start()
    {
        pylonCollider = GetComponent<Collider2D>();
        if (pylonCollider == null)  
        {
            Debug.LogError("Pylon collider is not set.");
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            isPylonOn = !isPylonOn;
            timer = 0f;
        }
        if (LightObject != null)
        {
            LightObject.SetActive(isPylonOn);
        }
    }
    public bool getisPylonOn()
    {
        return isPylonOn;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Player shocked!");
        if (isPylonOn && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<playerMovement>()?.ShockPlayer();
        }
    }
}
