using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyReference", menuName = "ScriptableObjects/EnemyReference", order = 1)]
public class EnemyReference : ScriptableObject
{
    public bool enemyInside = false;
}
