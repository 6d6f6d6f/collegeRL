using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Vector2 mousePos;

    public float moveSpeed = 5f;
    public float knockBackAmount = 10000f;

    public Rigidbody2D rb;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManagement.isGameOver)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            movement = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void KnockBack(GameObject other)
    {
        Vector2 hitDirection = (transform.position - other.transform.position).normalized;
        float timer = 0;
        float knockTime = 1f;
        while (knockTime > timer)
        {
            timer += Time.deltaTime;
            rb.AddForce(hitDirection * knockBackAmount);
        }
    }
}
