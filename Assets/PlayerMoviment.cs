using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    public float jumpForce;
    private bool doubleJump, isJumping, isGround;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        HorizontalMoviment();

        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space)) {
            if(isGround){
                Jump();
            }
        }
    }

    private void HorizontalMoviment(){
        float i = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        rb.velocity = new Vector2(i*100, rb.velocity.y);
    }

    void Jump(){
        rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }
}
