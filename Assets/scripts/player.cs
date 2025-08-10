using UnityEngine;

public class player : MonoBehaviour
{
   public GameObject tirPrefab;
    public GameObject explosionPrefab;  


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * 3;
        float moveY = Input.GetAxis("Vertical") * 3 ;

        this.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(moveX, moveY);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject tempTir = Instantiate(tirPrefab, this.transform.position, Quaternion.identity);
            tempTir.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 10);
            Destroy(tempTir, 2f); // Destroy the bullet after 2 seconds
        }
      
       
    }
 void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Alien"
            || collision.gameObject.tag == "Tir Ennemis")
        {
            Destroy(this.gameObject);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 0.3f); // Destroy the explosion after 1 second

        }
    }
}
