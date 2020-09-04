using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject enemyProjectile;
    Vector3 respwan = new Vector3(-8.5f, -3.4f, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -5 * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = respwan;
            Destroy(enemyProjectile);
            GameManager.lives--;
            GameManager.playGame = false;
        }

        if (collision.gameObject.tag == "Finish" || collision.gameObject.tag == "Base")
        {
            Destroy(enemyProjectile);
        }
    }
}
