using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool FacingRight = false;

    [SerializeField] GameObject[] objects;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minThres;
    [SerializeField] float MaxThres;

    public GameObject Spawner1;
    public float force = 200;
    private void Start()
    {
        StartCoroutine(ObjectSpawn());
    }
    IEnumerator ObjectSpawn()
    {
        while(true)
        {
           // var wanted = Random.Range(minThres, MaxThres);
            var position = new Vector3(Spawner1.transform.position.x, Spawner1.transform.position.y);
            GameObject gameObject = Instantiate(objects[Random.Range(0, objects.Length)], position, Quaternion.identity);
            if(FacingRight==false)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
            }
            else
            {
                gameObject.transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
            }
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }

}
