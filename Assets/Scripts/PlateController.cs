using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateController : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogue.SetActive(true);
            Invoke("DisableDialogue", 3f);
        }
    }

    private void DisableDialogue()
    {
        dialogue.SetActive(false);
    }
}
