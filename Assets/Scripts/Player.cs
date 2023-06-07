using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    List<Enemy> enemies;

    public float rotationSpeed;

    private void Awake()
    {
        enemies = ThisGameManager.Instance.GetEnemies();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Enemy enemy = enemies[Random.Range(0, enemies.Count)];

            transform.LookAt(new Vector3(enemy.transform.position.x, transform.position.y, enemy.transform.position.z));

            ThisGameManager.Instance.OnDead(enemy);
        }
    }
}
