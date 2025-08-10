using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject alienPrefab;
    float delaiApparition = 0;







    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delaiApparition += delaiApparition + Time.deltaTime;
        if (delaiApparition > 0.5f)
        {
            float spawnX = Random.Range(-8f, 8f);
            Instantiate(alienPrefab, new Vector2(spawnX, 3), Quaternion.identity);
            delaiApparition = 0;
        }
       


    }
}
