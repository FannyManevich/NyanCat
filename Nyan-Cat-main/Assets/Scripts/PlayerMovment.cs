using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private enum MovementState { walking, flying, catnip, turbo, hurt, rainbow}
    private Rigidbody2D rb;
    public float moveSpeed = 1.0f;
    private Vector2 direction = Vector2.right;


    public Transform leftWall;
    public Transform rightWall;
    public Transform topWall;
    public Transform bottomWall;

    private Animator anim;

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
        float dirX = Input.GetAxis("Horizontal");
         rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }

        UpdateAnimationState();

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, leftWall.position.x + 0.5f, rightWall.position.x - 0.5f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, bottomWall.position.y + 0.5f, topWall.position.y - 0.5f);
        transform.position = clampedPosition;   
    }
    private void FixedUpdate()
    {
        for (int i = addRainbow.Count - 1; i > 0; i --)
        {
            addRainbow[i].position = addRainbow[i - 1].position;
        }
        Vector2 newPosition = (Vector2)transform.position + direction * moveSpeed * Time.fixedDeltaTime;
        transform.position = newPosition;
    }   

    private void UpdateAnimationState()
    {
        MovementState state = MovementState.walking;
        anim.SetInteger("state",(int)state);
        switch (state)
        {
            case MovementState.walking:
                anim.SetInteger("state", (int)MovementState.walking);
                break;
            case MovementState.flying:
                anim.SetInteger("state", (int)MovementState.flying);
                break;
            case MovementState.catnip:
                anim.SetInteger("state", (int)MovementState.catnip);
                break;
            case MovementState.turbo:
                anim.SetInteger("state", (int)MovementState.turbo);
                break;
            case MovementState.hurt:
                anim.SetInteger("state", (int)MovementState.hurt);
                break;
            case MovementState.rainbow:
                anim.SetInteger("state", (int)MovementState.rainbow);
                break;
            default:
                anim.SetInteger("state", (int)MovementState.walking);
                break;
        }
    }

    private void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = addRainbow[addRainbow.Count - 1].position;
        addRainbow.Add(segment);
        anim.SetTrigger("EatPopTart");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Food"))
        {
            Grow();
        }
    }
}
