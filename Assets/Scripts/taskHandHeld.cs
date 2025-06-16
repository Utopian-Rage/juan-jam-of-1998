using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskHandHeld : MonoBehaviour
{
    private bool isVisible = false;
    [SerializeField] GameObject taskPullUp;

    // Update is called once per frame
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
