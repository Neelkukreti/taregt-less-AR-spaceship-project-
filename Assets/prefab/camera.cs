using UnityEngine;
using UnityEngine.UI;


public class camera : MonoBehaviour
{

    public GameObject cameratexture;
    public Button fireButton;

    /*  public camera(Button fireButton)
      {
          this.fireButton = fireButton;
      }
      */
    // Use this for initialization
    void Start()
    {
        WebCamTexture webCameraTexture = new WebCamTexture();
        cameratexture.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;
        webCameraTexture.Play();


        fireButton.onClick.AddListener(OnButtonDown);




        Input.gyro.enabled = true;
    }


    // Update is called once per frame
    void Update()
    {

        Quaternion camerarotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = camerarotation;

    }


    void OnButtonDown()
    {

        GameObject bullet = Instantiate(Resources.Load("bullet", typeof(GameObject))) as GameObject;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        bullet.transform.rotation = Camera.main.transform.rotation;
        bullet.transform.position = Camera.main.transform.position;
        rb.AddForce(Camera.main.transform.forward * 500f);
        Destroy(bullet, 3);

        GetComponent<AudioSource>().Play();
    }
}
