using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Scripting.APIUpdating;
using TMPro;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float currentSpeed = 7f;
    [SerializeField] float boostSpeed = 13f;
    [SerializeField] float regularSpeed = 7f;

    [SerializeField] TMP_Text boosttext;

    void Start()
    {
        boosttext.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            currentSpeed = boostSpeed;
            GetComponent<ParticleSystem>().Play();
            boosttext.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
        
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Worldcollision"))
        {
            currentSpeed = regularSpeed;
            boosttext.gameObject.SetActive(false);

        }
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {

    // }

    // Update is called once per frame
    void Update()
    {
        
        float steer = 0f; // for left and right 
        float move = 0f; // for forward and write
        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }   
        if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }
        
        float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;
        transform.Translate(0,moveAmount,0);// to move car in x y z.
        transform.Rotate(0,0,steerAmount);// to rotate car

    }

}
