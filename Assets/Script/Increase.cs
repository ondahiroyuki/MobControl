using JetBrains.Rider.Unity.Editor;
using UnityEngine;

public class Increase : MonoBehaviour
{
    public bool isActive { get; set; }

    private TextMesh textmesh;
    private int inc = 1;

    public bool isMove = false;
    public float radius = 5.0f;         // 円の半径
    public float moveDuration = 3.0f;  // 1周するのにかかる時間
    private Vector3 center;
    public float angle = 0.0f;
    private float angularSpeed;
    // Start is called before the first frame update
    void Start()
    {
        textmesh = GetComponentInChildren<TextMesh>();

        string textnum = textmesh.text;
        textnum = textnum.Substring(1);
        int.TryParse(textnum, out inc);

        center = transform.position;
        angularSpeed = 360.0f / moveDuration;  // 角速度 (360度 / 1周時間)
    }

        // Update is called once per frame
        void Update()
    {
        if (!isActive)
        {
            return;
        }


        if (isMove)
        {
            // 角度を更新
            angle += angularSpeed * Time.deltaTime;

            // 新しい位置を計算
            Vector3 newPosition = transform.right *  Mathf.Cos(angle * Mathf.Deg2Rad) * radius + center;
            transform.position = newPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mob"))
        {
            Mob mob = other.GetComponent<Mob>();
            if(mob.ExistIncreaseName(gameObject.name))
            {
                return;
            }
            else
            {

                for (int i = 1; i < inc; i++)
                {
                    Vector3 pos = other.transform.position;
                    pos.x += Random.Range(-0.4f, 0.4f);
                    pos.z += Random.Range(-0.4f, 0.4f);


                    GameObject ob = Instantiate(other.gameObject, pos , Quaternion.identity);
                    Mob mobn = ob.GetComponent<Mob>();
                    mobn.ExistIncreaseName(gameObject.name);

                    Mob mobo = other.GetComponent<Mob>();
                    mobn.frameCount = mobo.frameCount;

                    Rigidbody rb = other.GetComponent<Rigidbody>();
                    Rigidbody rbn = ob.GetComponent<Rigidbody>();
                    rbn.velocity = rb.velocity;
                }

            }
        }

    }
}
