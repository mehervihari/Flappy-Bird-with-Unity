using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;
    private GameManager manager;

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }
    private void OnEnable()
    {
        Vector3 pos = transform.position;
        pos.y = 0;
        transform.position = pos;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Obstacle")
        {
            manager.GameOver();
            //FindObjectOfType<GameManager>().GameOver();
        }
        else if (otherCollider.gameObject.tag == "Scorable")
        {
            manager.IncreaseScore();
            //FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
