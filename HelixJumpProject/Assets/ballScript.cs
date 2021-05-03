using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballScript : MonoBehaviour
{
    public float jumpSpeed;
    Rigidbody rb;
    public GameObject particleEff;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            var asdfs = collision.contacts[0].point;
            GameObject partic = Instantiate(particleEff,collision.contacts[0].point
             ,transform.rotation);
            float deger = 0.005555f;
            partic.transform.parent = collision.gameObject.transform;
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }

        if (collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(collision.gameObject.tag=="nextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
