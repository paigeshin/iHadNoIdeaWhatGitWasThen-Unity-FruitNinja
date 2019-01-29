using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruit;
    public float maxX; //it limits Fruit's maximum movement

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartSpawining", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //start Spawning
    public void StartSpawining()
    {
        InvokeRepeating("SpawnFruitGroups", 1, 6f);
    }

    //stop Spawning
    public void StopSpawning()
    {
        CancelInvoke("SpawnFruitGroups");
        StopCoroutine("SpawnFruit");
    }
    
    public void SpawnFruitGroups()
    {
        StartCoroutine("SpawnFruit"); //I guess if we wanna start a method which returns 'WaitForSeconds', we might need to call this function to get it started.
    }

    IEnumerator SpawnFruit()
    {
        for(int i = 0; i < 5; i++) { 
            float Rand = Random.Range(-maxX, maxX); //create random position according to 'maxX' value.
            Vector3 pos = new Vector3(Rand, transform.position.y, 0);
            GameObject f = Instantiate(fruit, pos, Quaternion.identity) as GameObject; //p1 - object to create, p2 - position, p3 - rotation
            
            //by using RigidBody attached in Inspector, we will add force.
            f.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15f), ForceMode2D.Impulse);//if we add Impulse, it's gonna move faster and faster

            //add Rotation 
            f.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-20f, 20f));

            yield return new WaitForSeconds(0.5f);
        }
    }

}
