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

        if(rb == null)
        {
            return;
        }

        if (frameCount > 60)
        {
            if ((cannon.transform.position - transform.position).magnitude < 3.0f)
            {
                rb.velocity = (cannon.transform.position - transform.position).normalized * 1.0f;
                rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z) * 1.0f;

            }
            else
            {
                rb.velocity = transform.forward * 1.0f;
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mob"))
        {
            // すべての子オブジェクトを取得
            Renderer[] childRenderers = GetComponentsInChildren<Renderer>();

            // 各子オブジェクトのRendererコンポーネントの色を変更
            foreach (Renderer renderer in childRenderers)
            {
                renderer.material.color = color;
            }
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(GetComponent<Rigidbody>());
            Destroy(gameObject, 0.1f);
        }
    }

}
