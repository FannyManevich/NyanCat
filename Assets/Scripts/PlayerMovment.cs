using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovment : MonoBehaviour {
   // private enum MovementState {walking,catnip,hurt}
    private Rigidbody2D rb;
    public float moveSpeed = 4.0f;

    private Vector2 moveDirection;
    public InputActionReference move;
    public InputActionReference attack;

    public Transform leftWall;
    public Transform rightWall;
    public Transform topWall;
    public Transform bottomWall;

    public Animator anim;

    public List<Transform> addRainbow;
    public Transform segmentPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
             
         addRainbow = new List<Transform>();
         addRainbow.Add(transform);
    }

    void Update()
    {

        moveDirection = move.action.ReadValue<Vector2>();
        
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, leftWall.position.x + 0.5f, rightWall.position.x - 0.5f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, bottomWall.position.y + 0.5f, topWall.position.y - 0.5f);
        transform.position = clampedPosition;
    }

    private void FixedUpdate()
    {
        for (int i = addRainbow.Count - 1; i > 0; i--)
        {
              addRainbow[i].position = addRainbow[i - 1].position;
        }
            Vector2 newPosition = (Vector2)transform.position + moveDirection * moveSpeed * Time.fixedDeltaTime;
            transform.position = newPosition;
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void OnEnable()
    {
        attack.action.started += Attack;
    }

    private void OnDisable()
    {
        attack.action.started -= Attack;
    }

    private void Attack(InputAction.CallbackContext obj)
    {
        Debug.Log("Attack");
    }
    
    private void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = addRainbow[addRainbow.Count - 1].position;
        addRainbow.Add(segment);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.CompareTag("Food"))
        {
             Grow();
        }
           
    }

}