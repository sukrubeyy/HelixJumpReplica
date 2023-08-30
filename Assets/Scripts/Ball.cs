using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
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
            GameObject TrailObject = Instantiate(particleEff,collision.contacts[0].point
             ,transform.rotation);
            TrailObject.transform.parent = collision.gameObject.transform;
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }

        if (collision.gameObject.tag == "obstacle")
        {
            GameManager.Instance.OpenLosePanel();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(collision.gameObject.tag=="nextLevel")
        {
            GameManager.Instance.OpenWinPanel();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
