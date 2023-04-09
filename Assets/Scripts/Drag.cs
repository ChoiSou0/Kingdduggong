using UnityEngine;
using System.Collections;
using System.Threading;

public class Drag : TurnManager
{
    public AudioSource S_collision;
    public int Myturn;
    [SerializeField] private GameObject Tale_Pc;
    [SerializeField] private float MaxPower = 20;
    private GameObject Pop_Pc;

    public static bool win;
    public static bool gool;

    public GameObject Arrow;
    public ArrowScale arrowScale;

    public bool isDelay = false;

    // Use this for initialization
    public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Pop_Pc = Resources.Load<GameObject>("Particle/Pop_Pc");
    }

    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (rb.velocity.x + rb.velocity.z == 0)
            Tale_Pc.SetActive(true);

        MouseLook();
    }
    void Initialization()
    {
        P_num = 0;
        win = false;
        gool = false;;
    }

    void MouseLook()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

        // Atan2를 이용하면 높이와 밑변(tan)으로 라디안(Radian)을 구할 수 있음
        // Mathf.Rad2Deg를 곱해서 라디안(Radian)값을 도수법(Degree)으로 변환
        float angle = Mathf.Atan2(
            this.transform.position.z - mouseWorldPosition.z,
            this.transform.position.x - mouseWorldPosition.x) * Mathf.Rad2Deg;

        // angle이 0~180의 각도라서 보정
        float final = -(angle + 180);
        // 로그를 통해서 값 확인
        //Debug.Log(angle + " / " + final);

        // Y축 회전
        Arrow.transform.rotation = Quaternion.Euler(new Vector3(90, final, 90));
    }

    void PowerControl()
    {
        Debug.Log("drag me down");
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
        offset.y = 6;
        rb.AddForce(offset * 0.7f, ForceMode.Impulse);
        //Tale_Pc.SetActive(true);
        arrowScale.ArrowScaleReset();
        StartCoroutine("Shoot");
        Arrow.SetActive(false);
        isDelay = true;
        StartCoroutine(Delay());

    }

    public Vector3 getVelocity()
    {
        return rb.velocity;
    }

    void OnMouseUp()
    {
        if (P_num == Myturn && isDelay == false && BtManager.nolace == false && BtManager.nolace2 == false)
        {
            PowerControl();
        }

    }

    private void OnMouseDrag()
    {
        if (P_num == Myturn && isDelay == false && BtManager.nolace == false&& BtManager.nolace == false)
        {
            Arrow.SetActive(true);
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

            arrowScale.ArrowScaleSizeControl(dist);
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.1f);
        while (rb.velocity.magnitude > 0.5 && transform.position.y >= 0) yield return new WaitForSeconds(0.1f);
        //if (GameManager.turn % 2 == 1) GameObject.Find("Main Camera").GetComponent<GameManager>().player2Turn();
        //else GameObject.Find("Main Camera").GetComponent<GameManager>().player1Turn();
        //GameManager.allowShoot = true;
    }

    IEnumerator Delay()
    {

        yield return new WaitForSeconds(5f);
        Debug.Log("ddd");
        if (P_num >= Myturn)
        {
            if (P_num == 3)
            {
                P_num = -1;
            }
            P_num = P_num + 1;

            isDelay = false;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 Pos = this.transform.position;

        if (collision.gameObject.CompareTag("Wall"))
        {
            S_collision.Play();
            Instantiate(Pop_Pc, Pos, Quaternion.identity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "CP")
        {
            gool = true;
        }

        if (other.gameObject.name == "Goll" && gool == true)
        {
            win = true;
        }
    }
}



//using UnityEngine;
//using System.Collections;

//public class Drag : MonoBehaviour
//{
//	// Use this for initialization
//	public Rigidbody rb;

//	void Start()
//	{
//		rb = GetComponent<Rigidbody>();
//	}

//	// Update is called once per frame
//	void Update()
//	{

//	}
//	void OnMouseUp()
//	{
//		Debug.Log("d");
//		float angle = GameObject.Find("Main Camera").GetComponent<CameraRotate>().getAngle();
//		Vector3 scrSpace = Camera.main.WorldToScreenPoint(transform.localPosition);
//		Vector3 offset = new Vector3(scrSpace.x - Input.mousePosition.x, 0, scrSpace.y - Input.mousePosition.y);
//		float dist = Mathf.Sqrt(offset.x * offset.x + offset.z * offset.z);
//		offset /= dist;

//		if (offset.z > 0) angle = (angle + Mathf.Rad2Deg * Mathf.Acos(offset.x)) % 360;
//		else angle = (angle + 360 - Mathf.Rad2Deg * Mathf.Acos(offset.x)) % 360;
//		offset.x = Mathf.Cos(Mathf.Deg2Rad * angle); offset.z = Mathf.Sin(Mathf.Deg2Rad * angle);
//		offset *= dist; offset.y = 6;
//		Debug.Log(angle);

//		rb.AddForce(offset, ForceMode.Impulse);
//	}
//}
