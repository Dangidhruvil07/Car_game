using NUnit.Framework;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    
    bool hasPackage;
    [SerializeField] float delay = 1f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // if(the tag is pacakage)
        // then (print picked up pacakage to console)
        if (collision.CompareTag("Package") && hasPackage == false)
        {
            Debug.Log("picked up package");
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            
            Destroy(collision.gameObject,delay);
        }
        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("package is divered");
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject,delay);
        }
        

    }
}
