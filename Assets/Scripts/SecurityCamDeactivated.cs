using UnityEngine;
using System.Collections;

public class SecurityCamDeactivated : MonoBehaviour {
    private bool hasOpenedYet = false;
    public Transform slideTo;

    public void openNow(){
        if (hasOpenedYet == false){
            Debug.Log("Play 'door slide' sound now");
            transform.position = slideTo.position;
            hasOpenedYet = true;
        }
    }
}
