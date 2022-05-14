using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadlineBehavior : MonoBehaviour
{
    ObjectPooler objectPooler;

    private void Awake()
    {
        objectPooler = ObjectPooler.Instance;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        objectPooler = ObjectPooler.Instance;
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            return;
        }
        collision.gameObject.SetActive(false);
        objectPooler.Addqueue(collision.gameObject.tag, collision.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectPooler = ObjectPooler.Instance;
        if (collision.gameObject.CompareTag("OBJPointtospawn"))
        {
            return;
        }
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            if (this.gameObject.CompareTag("ADL"))
            {
                objectPooler.Addqueue(collision.gameObject.tag, collision.gameObject);
                collision.gameObject.SetActive(false);
            }
            else
            {
                return;
            }
            
        }

        collision.gameObject.SetActive(false);
        objectPooler.Addqueue(collision.gameObject.tag, collision.gameObject);
    }
}
