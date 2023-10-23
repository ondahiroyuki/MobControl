using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public Color color = Color.white;

    private int frameCount = 0;
    private GameObject Goal = null;
    private List<string> increaseNames = new List<string>();
    private Rigidbody rb = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ++frameCount;
        if(frameCount > 60)
        {
            rb.velocity = new Vector3(transform.forward.x, 0.0f, transform.forward.z) * 1.0f;
        }

        if(Goal == null)
        {
            Goal = GameObject.FindGameObjectWithTag("EnemyBase");
        }
        if(frameCount > 300)
        {
            rb.velocity = (Goal.transform.position - transform.position).normalized * 1.0f;
            rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z) * 1.0f;
        }
    }

    public bool ExistIncreaseName(string name)
    {
        if(increaseNames.Contains(name))
        {
            return true;
        }
        else
        {
            increaseNames.Add(name);
            return false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EnemyBase") || collision.gameObject.CompareTag("Enemy"))
        {
            Renderer objectRenderer = GetComponentInChildren<Renderer>();
            objectRenderer.material.color = color;
            Destroy(gameObject, 0.1f);
        }
    }
}
