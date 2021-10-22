using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShips : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] float HP;
    [SerializeField] GameObject myPrefab1;
    [SerializeField] GameObject myPrefab2;

    private void RemoveSprite()
    {
        // When destroyed, automatically spawn off screen on the left a random
        // type (weaker or stronger)
        GameObject newEnemy;
        if (Random.Range(0, 2) == 1) newEnemy = myPrefab1;
        else newEnemy = myPrefab2;

        // Instantiate this new enemy at a random y value at the
        // top half of the screen on the Canvas
        Instantiate(newEnemy,
            new Vector3(-3.4f, Random.Range(0.0f, 9.0f), 90.0f),
            transform.rotation,
            GameObject.FindGameObjectWithTag("Canvas").transform);

        // Destroy the old enemy ship
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HP--;
        if (HP <= 0) RemoveSprite();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-18.0f, Random.Range(0.0f, 9.0f), 90);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.right * velocity * Time.deltaTime;
        transform.position += movement;

        if (!gameObject.GetComponent<Renderer>().isVisible &&
            transform.position.x > 0.0f)
            RemoveSprite();
    }
}
