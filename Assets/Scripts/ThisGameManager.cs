using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThisGameManager : MonoBehaviour
{
    [SerializeField] GameObject particleVFX;

    public static ThisGameManager Instance { get; private set;}

    public List<Enemy> enemies;

    private void Awake()
    {
        Instance = this;
    }
    public List<Enemy> GetEnemies()
    {
        return enemies;
    }

    public void OnDead(Enemy enemy)
    {
        enemies.Remove(enemy);
        Destroy(enemy.gameObject);
        GameObject explosion = Instantiate(particleVFX, enemy.transform.position, enemy.transform.rotation);
        Destroy(explosion, .75f);
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (enemies.Count <= 0)
        {
            ReSetGame();
        }
    }

    private void ReSetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
