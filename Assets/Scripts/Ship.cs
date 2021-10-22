using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject laser;

    void updateSprite(int sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprites[sprite];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.right * velocity * Time.deltaTime
            * Input.GetAxis("Horizontal");

        float movementDirection = movement.x;
        if (movementDirection < 0) updateSprite(1);
        else if (movementDirection > 0) updateSprite(2);
        else updateSprite(0);

        transform.position += movement;

        if(Input.GetButtonDown("Fire1"))
        {
            Vector3 laserPosition = new Vector3(transform.position.x,
                transform.position.y + 2.2f, transform.position.z);

            Instantiate(laser,
                laserPosition,
                transform.rotation,
                GameObject.FindGameObjectWithTag("Canvas").transform);
        }
    }

}
