using UnityEngine;
using System.Collections;
 
public class ClickToMove_V2 : MonoBehaviour
{
    /// <summary>
    /// 1 - The speed of the ship
    /// </summary>
    /// 
    public SpriteRenderer mySpriteRenderer;
    public Animator animator;
    public Vector2 speed = new Vector2(5f, 5f);

    //The position you clicked
    public Vector2 targetPosition;
    //That position relative to the players current position (what direction and how far did you click?)
    public Vector2 relativePosition;

    public Rigidbody2D rb;
    // 2 - Store the movement
    private Vector2 movement;

    private void Start()
    {
        targetPosition = transform.position;
    }

    private void OnEnable()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
       // Debug.Log(rb.velocity.magnitude);
        // 3 - Retrieve the mouse position
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));
        }

        //4 - Find the relative poistion of the target based upon the current position
        // Update each frame to account for any movement
        relativePosition = new Vector2(
            targetPosition.x - gameObject.transform.position.x,
            targetPosition.y - gameObject.transform.position.y);

        animator.SetFloat("WalkSpeed", rb.velocity.magnitude);

        if (targetPosition.x > transform.position.x)
        {
            mySpriteRenderer.flipX = false;
        }
        else if (targetPosition.x < transform.position.x)
        {
            mySpriteRenderer.flipX = true;
        }

    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Collidable")
        {

        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Collidable")
        {

        }
    }
    void FixedUpdate()
    {
        Vector2 SpeedMod = speed * relativePosition.normalized;
        // 5 - If you are about to overshoot the target, reduce velocity to that distance
        //      Else cap the Movement by a maximum speed per direction (x then y)

        if (SpeedMod.x * Time.deltaTime >= Mathf.Abs(relativePosition.x))
        {
            movement.x = relativePosition.x;
        }
        else
        {
            movement.x = SpeedMod.x;
        }
        if (SpeedMod.y * Time.deltaTime >= Mathf.Abs(relativePosition.y))
        {
            movement.y = relativePosition.y;
        }
        else
        {
            movement.y = SpeedMod.y;
        }

        // 6 - Move the game object using the physics engine
        rb.velocity = movement;



    }

    private void OnDisable()
    {
        rb.velocity = Vector2.zero;
        animator.SetFloat("WalkSpeed", rb.velocity.magnitude);
        targetPosition = transform.position;
    }
}