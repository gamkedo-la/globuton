using UnityEngine;
using System.Collections;

public class CheckedTrashCanAndFoundItem : MonoBehaviour {
    private bool hasCheckedYet = false;
    public Transform moveTo;

    public void checkNow(){
        if (hasCheckedYet == false){
            Debug.Log("Play a sound now");
            transform.position = moveTo.position;
            hasCheckedYet = true;
        }
    }
}
