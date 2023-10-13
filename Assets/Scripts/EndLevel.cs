using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private Animator cutsceneAnim1, cutsceneAnim2;
    [SerializeField] private GameObject bg;
    [SerializeField] private ParticleSystem cutsceneParticle;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayableDirector director = gameObject.GetComponent<PlayableDirector>();
        cutsceneParticle.Play();
        if (col.gameObject.tag == "Player")
        {
            bg.SetActive(true);
            director.Play();
            cutsceneAnim1.SetTrigger("cutscene");
            cutsceneAnim2.SetTrigger("cutscene");
            Invoke("RestartGame", 5f);            
        }
    }

    private void RestartGame(){
        SceneManager.LoadScene("Menu_Scene");
    }
}
