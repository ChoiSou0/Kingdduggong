using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavAI : MonoBehaviour
{
    public Transform[] CheckPoint;
    public int CP = 0; //체크 포인트
    public GameObject AI_watching; // 보는애
    bool CPE = false;

    private float RanPower;
    [SerializeField] private float MaxPower;

    // Use this for initialization
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void AITurn()
    {
        RanPower = Random.Range(20, 30);
        rb.AddForce(AI_watching.transform.forward * MaxPower, ForceMode.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        AI_watching.transform.LookAt(CheckPoint[CP]);
        if (Input.GetKeyDown(KeyCode.A))
        {
            AITurn();
            Debug.Log("d");
        }
    }
    public Vector3 getVelocity()
    {
        return rb.velocity;
    }
    void OnMouseUp()
    {
        /*Debug.Log("d");
        float angle = 0;
        Vector3 scrSpace = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 offset = new Vector3(scrSpace.x - Input.mousePosition.x, 0, scrSpace.y - Input.mousePosition.y);
        if (offset.x > MaxPower)
            offset.x = MaxPower;
        else if (offset.x < -MaxPower)
            offset.x = -MaxPower;
        if (offset.z > MaxPower)
            offset.z = MaxPower;
        else if (offset.z < -MaxPower)
            offset.z = -MaxPower;
        float dist = Mathf.Sqrt(offset.x * offset.x + offset.z * offset.z);
        offset /= dist;
        if (offset.z > 0)
            angle += Mathf.Rad2Deg * Mathf.Acos(offset.x);
        else
            angle += 360 - Mathf.Rad2Deg * Mathf.Acos(offset.x);
        offset.x = Mathf.Cos(Mathf.Deg2Rad * angle);
        offset.z = Mathf.Sin(Mathf.Deg2Rad * angle);
        offset *= dist;
        Debug.Log(offset);
        offset.y = 6;*/
        
        

        

    }
    IEnumerator CPEnter()
    {
        yield return new WaitForSeconds(0.1f);
        CPE = false;
        //while (rb.velocity.magnitude > 0.5 && transform.position.y >= 0) yield return new WaitForSeconds(0.1f);
        //if (GameManager.turn % 2 == 1) GameObject.Find("Main Camera").GetComponent<GameManager>().player2Turn();
        //else GameObject.Find("Main Camera").GetComponent<GameManager>().player1Turn();
        //GameManager.allowShoot = true;
    }

    private void CPON()
    {
        CPE = true;
        StartCoroutine("CPEnter");
        
        Debug.Log("CPON");
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "CheckPoint1" && CPE==false)
        {
            CP = 1;
            CPON();
            Debug.Log(CP);
        }

        if (other.gameObject.name == "CheckPoint2" && CPE == false)
        {
            CP = 2;
            CPON();
            Debug.Log(CP);
        }

        if (other.gameObject.name == "CheckPoint3" && CPE == false)
        {
            CP = 3;
            CPON();
            Debug.Log(CP);
        }

        if (other.gameObject.name == "CheckPoint4" && CPE == false)
        {
            CP = 4;
            CPON();
            Debug.Log(CP);
        }

/*        if (other.gameObject.name == "CheckPoint5")
        {
            CP = 1;
        }*/

    }
}

