using UnityEngine;

#region Code
public class MovementScript : MonoBehaviour
{
    #region SerializeFields
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private Rigidbody2D RB;
    [SerializeField] private GroundCheck groundCheck;

    #endregion
    #region Fields
    private bool _canJump = true;
    private bool _canJumpTwice = true;
    public DashState dashState;
    public float dashTimer;
    public float maxDash = 1f;
    private float maxDashSpeed = 10f;

    public Vector2 savedVelocity;

    #endregion

    #region Function
    void Update()
    {
        HorizontalMovement();
        Jump();
        DashLogic();
    }

    #region Dashing logic
    private void DashLogic()
    {
        var isDashKeyDown = Input.GetKeyDown(KeyCode.LeftShift);
        switch (dashState)
        {
            case DashState.Ready:
                if (isDashKeyDown)
                {
                    savedVelocity = RB.velocity;
                    dashState = DashState.Dashing;
                }
                break;
            case DashState.Dashing:
                dashTimer += Time.deltaTime * maxDashSpeed;
                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    RB.velocity = savedVelocity;
                    RB.AddForce(new Vector2(RB.velocity.x * maxDashSpeed, RB.velocity.x), ForceMode2D.Impulse);
                    dashState = DashState.Cooldown;
                }
                break;
            case DashState.Cooldown:
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                }
                break;
        }
    }
    #endregion

    #region Horizontal Movement
    private void HorizontalMovement()
    {
        Vector2 vel = RB.velocity;
        vel.x = Input.GetAxis("Horizontal") * speed;
        RB.velocity = vel;
       
    }
    #endregion

    #region Jumping logic
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.Contacts > 0 && _canJump )
        {
            RB.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            _canJump = false;
        } else if (Input.GetKeyDown(KeyCode.Space) && _canJumpTwice )
        {
            RB.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            _canJumpTwice = false;
        } else {
            if (groundCheck.Contacts == 1) 
            {
                _canJump = true;
                _canJumpTwice = true;
            }
        }
    }
    #endregion

    #endregion
}
#endregion
#region ENUM DashState
public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}
#endregion