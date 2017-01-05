using UnityEngine;
using System.Collections;

public class CodeSlideUnderDoor : MonoBehaviour
{
    private bool hasSlidYet = false;
    public Transform slideTo;

    public void slideNow()
    {
        if (hasSlidYet == false)
        {
            Debug.Log("Play slide sound now");
            transform.position = slideTo.position;
            hasSlidYet = true;
        }
    }
}
