using UnityEngine;
using UnityEngine.SceneManagement;

public class RigidbodyMovement : MonoBehaviour
{
	public Rigidbody2D rigidbodys; // The Rigidbody component that you want to move
	public float speed = 0.2f; // The speed at which the Rigidbody should move
	public float jumpForce = 8f; // The force with which the Rigidbody should jump
	public float dashForce = 8f; // the for whith which the Rigidbody should dash
	public LayerMask groundLayers; // The layers that should be considered as ground for the purpose of jumping
	public float maxforce;
	public float friction;
	public float stopFriction;
	public float scale;
	public SpriteRenderer charIcon;

	private bool isGrounded; // Whether the Rigidbody is currently grounded
	private float Grounded;
	private float jumpTime;
	private float jT;

	void FixedUpdate()
	{
		// Check if the Rigidbody is grounded
		isGrounded = Physics2D.OverlapCircle(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), scale, groundLayers);

		// Get input from the horizontal axis (left and right arrow keys or A and D keys)
		float horizontalInput = Input.GetAxis("Horizontal");

		// Calculate the direction in which the Rigidbody should move
		Vector2 movementDirection = new Vector2(horizontalInput, 0);

		// Normalize the movement direction to ensure that the Rigidbody moves at a constant speed
		//movementDirection = movementDirection.normalized;

		// Calculate the velocity of the Rigidbody based on the movement direction and speed
		Vector2 velocity = movementDirection * speed;

		// Set the Rigidbody's velocity
		//rigidbodys.velocity += new Vector2(velocity.x, 0);
		if (((int)rigidbodys.velocity.x*2) != 0)
            {
				if (((int)rigidbodys.velocity.x*2) > 0)
                {
					charIcon.flipX = false;
                }
                else
                {
					charIcon.flipX = true;
                }
            }
		if (isGrounded)
		{
			Grounded = 1;
			rigidbodys.velocity += new Vector2(velocity.x, 0);
			//rigidbodys.velocity = new Vector2(rigidbodys.velocity.x * friction, rigidbodys.velocity.y);
			rigidbodys.velocity = new Vector2(Mathf.Clamp(rigidbodys.velocity.x, -maxforce, maxforce), rigidbodys.velocity.y);
			if (Input.GetAxisRaw("Horizontal") == 0)
			{
				rigidbodys.velocity = new Vector2(rigidbodys.velocity.x / stopFriction, rigidbodys.velocity.y);
			}
			
		}
		else
		{
			rigidbodys.velocity += new Vector2(velocity.x/5, 0);
			//rigidbodys.velocity = new Vector2(Mathf.Clamp(rigidbodys.velocity.x, -maxforce*2, maxforce*2), rigidbodys.velocity.y);
		}


		jumpTime++;
	}
	private void Update()
	{

		// If the space bar is pressed and the Rigidbody is grounded, add a force to make it jump
		if (Input.GetButtonDown("Jump"))
		{
			if (jT <= jumpTime - 5)
			{
				if (isGrounded)
				{
					rigidbodys.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
					jT = jumpTime;
				}
			}
		}
		if (Input.GetButtonDown("Reset"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		if (Input.GetButtonDown("Dash"))
		{
			if (jT <= jumpTime - 5)
			{
				if (Grounded != 0)
				{
					if (Input.GetAxisRaw("Horizontal") != 0)
					{
						if (isGrounded)
						{
							rigidbodys.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * dashForce, rigidbodys.velocity.y);
						}
                        else
                        {
							rigidbodys.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * dashForce, dashForce / 2);
						}
						Grounded--;
						jT = jumpTime;
					}
				}
			}
		}
	}
}