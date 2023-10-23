using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject Mob = null;
    private float sen = 0.02f;

    private Vector3 initPos = Vector3.zero;
    private Vector3 touchPos = Vector3.zero;
    private int FrameCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initPos = transform.position;
            touchPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 move = Input.mousePosition - touchPos;
            transform.position = new Vector3(initPos.x + move.x * sen, initPos.y, initPos.z); ;
            
            //à⁄ìÆêßå¿
            if(transform.position.x < -2.5f)
            {
                transform.position = new Vector3(-2.5f, transform.position.y, transform.position.z) ;
            }
            if(2.5f < transform.position.x)
            {
                transform.position = new Vector3(2.5f, transform.position.y, transform.position.z) ;
            }

            //Mobèoåª
            ++FrameCount;
            if (FrameCount % 60 == 0)
            {
                GameObject ob = Instantiate(Mob, transform.position + transform.forward * 0.5f, Quaternion.Euler(0.0f, 0.0f, 0.0f));

                Rigidbody rb = ob.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 3.0f, ForceMode.Impulse);
            }



        }
    }
}
