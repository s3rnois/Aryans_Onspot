using UnityEngine;

public class motion : MonoBehaviour
{
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  public Rigidbody cube;
  public float FForce;
  public float SForce;
  private Vector3 originalPosition;
  private Vector3 tel = new Vector3(-5, 1, 50);
  private Vector3 won = new Vector3(-30, 1, 0);

  void Start()
  {
    originalPosition = transform.position;

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey("d"))
      cube.AddForce(SForce, 0, 0);

    if (Input.GetKey("a"))
      cube.AddForce(-SForce, 0, 0);

    if (Input.GetKey("w"))
      cube.AddForce(0, 0, FForce);

    if (Input.GetKey("s"))
      cube.AddForce(0, 0, -FForce);
  }
  void OnCollisionEnter(Collision col)
  {
    // Check if the collided object is named "Cube1"
    if (col.gameObject.CompareTag("Respawn"))
    {
      // Reset position to the original starting position
      transform.position = originalPosition;

    }
    if (col.gameObject.CompareTag("Teleport"))
    {
      // Reset position to the original starting position
      transform.position = tel;

    }
        if (col.gameObject.CompareTag("Finish"))
        {
            // Reset position to the original starting position
            transform.position = won;
           
        }
  }
    
}
