using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D          myRigidbody;
    public int                  MovementSpeed;
    public int                  JumpSpeed;
    public Vector2              VelocityVector;
    public CapsuleCollider2D    myCapsuleCollider;
    public KeyCode              JumpKey;
    public ForceMode2D          JumpForce;
    public GroundSensor         GroundSensor;
    public bool                 FacingLeft;
    public Vector3              AuxScale;
    public KeyCode              ShootKey;
    public Projectile           ShotPrefab;
    public Transform            ShotPoint;
    public Animator             myAnimator;
    public string               MovementBoolName;
    public string               JumpingBoolName;
    public WallSensor           WallSensor;
    public string               DeadBoolName;
    public Health               myHealth;
    public SpriteRenderer       DeathMessage;
    public SpriteRenderer       WinMessage;

    private void Awake()
    {
        myAnimator = this.GetComponent<Animator>();
        myHealth = this.GetComponent<Health>();
        myCapsuleCollider = this.GetComponent<CapsuleCollider2D>();
    }
    private void Update()
    {
        if (myHealth.IsAlive)
        {
            if (Input.GetKeyDown(ShootKey))
            {
                Projectile newProjectile = Instantiate<Projectile>(ShotPrefab, ShotPoint.position, Quaternion.identity);
                if (FacingLeft)
                {
                    newProjectile.Speed = -newProjectile.Speed;
                }
            }

            if (GroundSensor.IsGrounded() && Input.GetKeyDown(JumpKey))
            {
                myRigidbody.AddForce(Vector2.up * JumpSpeed, JumpForce);
            }
        }
    }
    private void FixedUpdate()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");

        if (myHealth.IsAlive)
        {

            if (!WallSensor.HasContact())
            {
                VelocityVector = myRigidbody.velocity;
                VelocityVector.x = MovementSpeed * HorizontalInput;
                myRigidbody.velocity = VelocityVector;
            }
        }

        if (myHealth.IsAlive)
        {


            if (HorizontalInput < 0f)
            {
                if (!FacingLeft)
                {
                    FacingLeft = true;
                    FlipScale();
                }
            }
            else if (HorizontalInput > 0f)
            {
                if (FacingLeft)
                {
                    FacingLeft = false;
                    FlipScale();
                }

            }

            myAnimator.SetBool(MovementBoolName, (!Mathf.Approximately(HorizontalInput, 0f)));
            myAnimator.SetBool(JumpingBoolName, !GroundSensor.IsGrounded());
        }

    }

    private void FlipScale()
    {
        AuxScale = transform.localScale;
        AuxScale.x = -AuxScale.x;
        transform.localScale = AuxScale;
    }

    public void ApplyDeathEffects()
    {
        myAnimator.SetBool(DeadBoolName, true);
        DeathMessage.enabled = true;
        myCapsuleCollider.enabled = false;
        myRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void ApplyWinEffects()
    {
        WinMessage.enabled = true;
        myRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

}





