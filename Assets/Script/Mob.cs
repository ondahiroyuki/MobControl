using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public Color color = Color.white;

    public int frameCount = 0;
    private GameObject goal = null;
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

        if (rb == null)
        {
            return;
        }

        if (goal == null)
        {
            goal = GameObject.FindGameObjectWithTag("EnemyBase");
            if(goal == null )
            {
                return;
            }
        }



        if (frameCount > 60)
        {
            if ((goal.transform.position - transform.position).magnitude < 3.0f)
            {
                rb.velocity = (goal.transform.position - transform.position).normalized * 1.0f;
                rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z) * 1.0f;

            }
            else
            {
                rb.velocity = transform.forward * 1.0f;
                //rb.velocity = new Vector3(transform.forward.x, 0.0f, transform.forward.z) * 1.0f;

            }
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
