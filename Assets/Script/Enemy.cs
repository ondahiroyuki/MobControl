using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Color color = Color.white;

    private GameObject cannon = null;
    private Rigidbody rb = null;
    private int frameCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        cannon = GameObject.FindGameObjectWithTag("Cannon");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ++frameCount;
        if(frameCount > 60)
        {
            rb.velocity = (cannon.transform.position - transform.position).normalized * 1.0f;
            rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z) * 1.0f;

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mob"))
        {
            Renderer objectRenderer = GetComponentInChildren<Renderer>();
            objectRenderer.material.color = color;
            Destroy(gameObject, 0.1f);
        }
    }

}
