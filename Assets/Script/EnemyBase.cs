using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public GameObject enemy;

    private TextMesh textmesh;
    private int frameCount = 0;
    private bool inst= false;

    // Start is called before the first frame update
    void Start()
    {
        textmesh = GetComponentInChildren<TextMesh>();

    }

    // Update is called once per frame
    void Update()
    {
        ++frameCount;
        if(inst)
        {
            if(frameCount % 5 == 0)
            {
                Vector3 pos = transform.position + transform.forward * -1.0f;
                pos.x += Random.Range(-0.9f, 0.9f);
                pos.z += Random.Range(-0.9f, 0.9f);
                GameObject ob = Instantiate(enemy, pos, Quaternion.Euler(0.0f, 180.0f, 0.0f));

                Rigidbody rb = ob.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * -5.0f, ForceMode.Impulse);
            }

            if(frameCount > 30)
            {
                frameCount = 0;
                inst = false;
            }
        }
        else
        {


            if(frameCount > 300)
            {
                frameCount = 0;
                inst = true;
            }
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mob"))
        {
            int.TryParse(textmesh.text, out int num);
            --num;

            if (num <= 0)
            {
                num = 0;
                Destroy(gameObject, 0.5f);

                GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Mob");
                foreach (GameObject obj in objectsToDestroy)
                {
                    Destroy(obj, 0.5f);
                }

                GameObject[] destroyob = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject obj in destroyob)
                {
                    Destroy(obj, 0.5f);
                }
            }

            textmesh.text = num.ToString();
        }

    }

}
