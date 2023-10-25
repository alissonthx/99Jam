using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{

    private void Start(){
        Invoke("EndFade", 1.0f);
    }
    private void EndFade(){
        gameObject.SetActive(false);
    }
}
