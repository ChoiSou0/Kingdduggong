using UnityEngine;
using System.Collections;
using System.Threading;

public class Drag : MonoBehaviour
{
    [SerializeField] private float MaxPower = 20;

    // Use this for initialization
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public Vector3 getVelocity()
    {
        return rb.velocity;
    }
    void OnMouseUp()
    {
        Debug.Log("d");
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
        offset.y = 6;
        rb.AddForce(offset * 4, ForceMode.Impulse);

        StartCoroutine("Shoot");

    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.1f);
        while (rb.velocity.magnitude > 0.5 && transform.position.y >= 0) yield return new WaitForSeconds(0.1f);
        //if (GameManager.turn % 2 == 1) GameObject.Find("Main Camera").GetComponent<GameManager>().player2Turn();
        //else GameObject.Find("Main Camera").GetComponent<GameManager>().player1Turn();
        //GameManager.allowShoot = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        
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