using UnityEngine;
public class taskHandHeld : MonoBehaviour
{
    private bool isVisible = false;
    [SerializeField] GameObject taskPullUp;
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            if (!isVisible)
            {
                taskPullUp.SetActive(true);
                isVisible = true;
            }
        }
        else
        {
            if (isVisible)
            {
                taskPullUp.SetActive(false);
                isVisible = false;
            }
        }
    }
}
