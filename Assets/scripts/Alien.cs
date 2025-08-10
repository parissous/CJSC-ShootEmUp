using UnityEngine;

public class Alien : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject TirEnnemisprefab;
    float delayApparition = 0;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      float moveX= Random.Range(-1f, 1f);
        this.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(moveX, -1f);

        Destroy(this.gameObject, 10f); // Destroy the alien after 5 seconds if it doesn't collide with anything
    }

    // Update is called once per frame
    void Update()
    {
        delayApparition += delayApparition + Time.deltaTime;
       
        if (delayApparition > 1f)
        {
            
             GameObject tempTir = Instantiate(TirEnnemisprefab, this.transform.position, Quaternion.identity);
            tempTir.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, -3);
            Destroy(tempTir, 10f); 
            delayApparition = 0;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tir")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 0.3f); // Destroy the explosion after 1 second
        }



       
    }
}
