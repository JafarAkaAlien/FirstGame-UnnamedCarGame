using UnityEngine;

public class movement : MonoBehaviour
{
    CharacterController cont;
    Vector3 playerVelo;
    [SerializeField] private float playerSpeed = 0;
    public float rotateSpeed = 30;
    public float SimForce = 5;
    void Start()
    {
        cont  = GetComponent<CharacterController>();
    }


    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal")*rotateSpeed*Time.deltaTime, 0);
        playerVelo = transform.TransformDirection(Vector3.forward);
        float move = Input.GetAxis("Vertical");
        if(playerSpeed>0.1 && move<=0)
        {
            speedUp(25 * Time.deltaTime*-1);
        }
        else if(playerSpeed<-0.1 && move >= 0)
        {
            speedUp(25 * Time.deltaTime);
        }
        if (move > 0 && playerSpeed<100)
        {
            speedUp(SimForce * Time.deltaTime);
        }
        else if (move < 0 && playerSpeed>-20)
        {
            speedUp(SimForce * Time.deltaTime * -1);
        }
        
        cont.SimpleMove(playerVelo * playerSpeed);
    }
    void speedUp(float force)
    {
        playerSpeed += force;
    }
}
