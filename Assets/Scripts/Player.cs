using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite[] sprites;

    
    private int spriteIndex;

    private Vector3 direction;

    public float gravity = -9.81f;

    public float strength = 5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); //baþka bir iþlevi çaðýrmanýn bir yoludur, 0.15f sürede sprite deðiþecek
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //space veya sol click yukarý doðru hareket
        {
            direction = Vector3.up * strength;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // ekrana ilk giriþ olduðunda baþlattýðýný belirtmek amaçlý
            if ((touch.phase == TouchPhase.Began))
            {
                direction = Vector3.up * strength;
            }
            
        }

        direction.y += gravity * Time.deltaTime; // kuvvetin y ekseninde olduðunu tanýmlýyoruz.
        transform.position += direction * Time.deltaTime; // kuþumuzun konumu

    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
        
        
    }

}
