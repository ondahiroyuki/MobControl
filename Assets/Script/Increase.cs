using JetBrains.Rider.Unity.Editor;
using UnityEngine;

public class Increase : MonoBehaviour
{
    private TextMesh textmesh;
    private int inc = 1;
    // Start is called before the first frame update
    void Start()
    {
        textmesh = GetComponentInChildren<TextMesh>();

        string textnum = textmesh.text;
        textnum = textnum.Substring(1);
        int.TryParse(textnum, out inc);

    }

    // Update is called once per frame
    void Update()
    {
        
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
                    pos.x += Random.Range(-0.5f, 0.5f);
                    pos.z += Random.Range(-0.5f, 0.5f);


                    GameObject ob = Instantiate(other.gameObject, pos , Quaternion.identity);
                    Mob obMob = ob.GetComponent<Mob>();
                    obMob.ExistIncreaseName(gameObject.name);

                    Rigidbody rb = other.GetComponent<Rigidbody>();
                    Rigidbody rbn = ob.GetComponent<Rigidbody>();
                    rbn.velocity = rb.velocity;
                }

            }
        }

    }
}
