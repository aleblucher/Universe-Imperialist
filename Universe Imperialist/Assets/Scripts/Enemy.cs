using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float timer = 0;
    float timeToMove = 0.5f;
    int numOfMovements = 0;
    float speed = 0.30f;

    public GameObject enemy;
    public GameObject enemyProjectile;
    public GameObject enemyProjectileClone;

    Vector3 respwan = new Vector3(-8.5f, -3.4f, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move down after 12 stops
        if (GameManager.playGame == true) {
            if (numOfMovements == 12)
            {
                transform.Translate(new Vector3(0, -0.5f, 0));
                numOfMovements = 0;
                speed = -speed;
            }

            // move sideways on timed intervals
            timer += Time.deltaTime;
            if (timer > timeToMove && numOfMovements < 12)
            {
                transform.Translate(new Vector3(speed, 0));
                timer = 0;
                numOfMovements++;
            }

            if(GameManager.playGame == true)
            {
                fireEnemyProjectile();
            }
            
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = respwan;
            GameManager.lives--;
            GameManager.playGame = false;
        }

        if (collision.gameObject.tag == "Base")
        {
            Destroy(collision.gameObject);
        }
    }


        void fireEnemyProjectile()
    {
        if (Random.Range(0f, 750f) < 1)
        {
            enemyProjectileClone = Instantiate(enemyProjectile, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.3f, 0), enemy.transform.rotation) as GameObject;
            
        }
    }
}
