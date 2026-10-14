using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;
    [SerializeField] private KickWeapon _leftKick;
    [SerializeField] private KickWeapon _rightKick;

    private bool _isGrounded;
    private bool _facingLeft;
    private int _points;

    // ------------------------------------------------------------------------
    private void Update()
    {
        // Detect input to move player left/right
        _rigidbody.linearVelocity = new Vector2(
            Input.GetAxis("Horizontal") * _speed,
            _rigidbody.linearVelocity.y
        );

        // Detect input to jump
        if (Input.GetAxis("Vertical") > 0 && _isGrounded)
        {
            _rigidbody.linearVelocity = new Vector2(
                _rigidbody.linearVelocity.x,
                _jump
            );
            _isGrounded = false;
        }

        // Change character facing 
        if (Input.GetAxis("Horizontal") < 0 && !_facingLeft)
        {
            _spriteRenderer.flipX = true;
            _facingLeft = true;
        }
        else if (Input.GetAxis("Horizontal") > 0 && _facingLeft)
        {
            _spriteRenderer.flipX = false;
            _facingLeft = false;
        }

        // Kick if the player presses space
        if (Input.GetKey(KeyCode.Space))
        {
            Kick();
        }

        // Set animation state params
        _animator.SetBool("walking", _rigidbody.linearVelocity.x != 0.0f);
        _animator.SetBool("inAir", _rigidbody.linearVelocity.y != 0.0f);
    }

    // ------------------------------------------------------------------------
    public void SetGameOver ()
    {
        this.enabled = false;
    }

    // ------------------------------------------------------------------------
    // Activates the colliders that kick objects
    private void Kick()
    {
        if (_facingLeft)
        {
            _leftKick.ActivateKick();
        }
        else
        {
            _rightKick.ActivateKick();
        }

        _animator.SetTrigger("kick");
    }

    // STEP 10 -----------------------------------------------------------------
    // This method is called when the player kicks a Kickable item.
    public void IncreasePoints()
    {
        _points += 1;
        _pointsText.text = _points.ToString();
        // Inside this method, increase the value of _points by one,
        // and update the _pointsText text with text displaying the new value of _points.
        
    }
    // STEP 10 -----------------------------------------------------------------

    // ------------------------------------------------------------------------
    // Don't let the player jump again until they've touched the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }
}
