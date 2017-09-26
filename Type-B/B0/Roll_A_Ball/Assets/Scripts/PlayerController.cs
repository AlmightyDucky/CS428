using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Members
    [Range(1, 2)]
    public int playerID;

    public float speed = 10f;
    public float jumpHeight = 10f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private bool isOnGround = true;

    private string strafeAxis;
    private string fowardAxis;
    private string jumpButton;

    public GameManager instance;

    private Rigidbody rb;
    #endregion

    #region PlayerController Methods
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (playerID == 1)
        {
            strafeAxis = "HorizontalPlayer1";
            fowardAxis = "VerticalPlayer1";
            jumpButton = "JumpPlayer1";
        }

        if (playerID == 2)
        {
            strafeAxis = "HorizontalPlayer2";
            fowardAxis = "VerticalPlayer2";
            jumpButton = "JumpPlayer2";
        }
    }

    void FixedUpdate()
    {
        if (GameManager.timeRanOut)
        {
            this.gameObject.SetActive(false);
        }

        float moveHorizontal = Input.GetAxis(strafeAxis);
        float moveVertical = Input.GetAxis(fowardAxis);
        float jump = 0f;

        if (isOnGround && Input.GetButtonDown(jumpButton))
        {
            isOnGround = false;
            jump = jumpHeight;
        }

        Vector3 movement = new Vector3(moveHorizontal, jump, moveVertical);

        rb.AddForce(movement * speed * Time.deltaTime);

        //improved jump
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton(jumpButton))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);

            GameManager.instance.SetScoreText(playerID, 1);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (collision.collider.CompareTag("Wall"))
        {
            GameManager.instance.SetScoreText(playerID, -1);
        }

        if (collision.collider.CompareTag("Player"))
        {
            if ((this.transform.position.y + 0.02) < collision.collider.transform.position.y)
            {
                print("Player " + playerID + ": " + this.transform.position.y + "; Other: " + collision.collider.transform.position.y);
                GameManager.instance.SetScoreText(playerID, -1);
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }

    #endregion
}
