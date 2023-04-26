using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [HideInInspector]
    public GameObject enm;
    private EnemyMovement enemyMovement;
    private Rigidbody2D rbEnemy;

    [SerializeField]
    private GameObject enemyPrefab;
    
    void Start()
    {
        GameObject enm = Instantiate(enemyPrefab, transform.position, Quaternion.identity);        
    }

    void Update()
    {

    }
}
