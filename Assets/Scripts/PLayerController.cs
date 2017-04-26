using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PLayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = string.Empty;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        countText.text = string.Format("Count: {0}", count);
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}
