using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public GameObject projectileClone;
    public GameObject music;

    private float bound = 9;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.lives > 0)
        {
            movement();
            fireProjectile();

        }
        
    }



    void movement()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
   
            transform.Translate(new Vector3(-5 * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(5 * Time.deltaTime, 0, 0));
        }

    }

    void fireProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space) && projectileClone == null)
        {
            projectileClone = Instantiate(projectile, new Vector3(player.transform.position.x, player.transform.position.y + 0.1f, 0), player.transform.rotation) as GameObject;
            music.GetComponent<SoundManager>().PlaySound();
        }
    }

}



