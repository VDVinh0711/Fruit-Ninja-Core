using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public Transform parFruit;
    private  float minforce = 0.5f;
    private float maxforce = 1.0f;
    private Rigidbody2D fruitRB;
    public float gravity = 0.75f;
    

    private void Awake()
    {
        fruitRB = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
       if(collision.transform.CompareTag("Border"))
        {
            GameManager.Innstance.countMiss++;
            Destroy(gameObject);
            if (GameManager.Innstance.countMiss++ < 3) return;
            Debug.Log("Call this method");
            GameManager.Innstance.GameOver();
        }
        if (collision.transform.CompareTag("Blade"))
        {
           Transform newPar =   Instantiate(parFruit, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(newPar.gameObject,0.5f);
        }
    } 
    private void Update()
    {
       
    }
    private void OnEnable()
    {
        AddForceFruit();
    }
    private float RandomForce()
    {
        return Random.Range(minforce, maxforce);
    }
    public void AddForceFruit()
    {
       // fruitRB = GetComponent<Rigidbody2D>();
        if (fruitRB == null) return;
        Physics2D.gravity = Physics2D.gravity * gravity;
        Vector2 camPos = Camera.main.transform.position;
        camPos.x = Random.Range (camPos.x -5, camPos.x + 5);
        camPos.y = Random.Range(camPos.y - 5, camPos.y + 5);
        Vector2 objPos = transform.position;
        Vector2 direction = camPos - objPos;
        fruitRB.AddForce(direction * RandomForce(), ForceMode2D.Impulse);
    }
}
