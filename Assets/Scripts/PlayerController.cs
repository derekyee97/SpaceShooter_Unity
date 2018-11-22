using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   public float speed;
    public float tilt; 
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    private Rigidbody rb;     //since new unity cant get direct access to rigidbody need reference
    private AudioSource audio;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>(); //get ref to audio clip of shooting sound
    }
    private void Update()
    {
        if(Input.GetButton("Fire1")&&Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);  //instantiates a shotInstantiate dont need ref
            audio.Play();   //plays shooting sound 
        }
        
    }
    private void FixedUpdate() //will be called auto bh unity before each fixed physics step
    {
        float moveHorizontal = Input.GetAxis("Horizontal");  //input in x dir
        float moveVertical = Input.GetAxis("Vertical");    //input in y dir
        Vector3 movement=new Vector3(moveHorizontal, 0.0f, moveVertical);  //x y z directions respectively
        rb.velocity = movement * speed;
        rb.position = new Vector3   //limits where can go in screen play
            (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),   //collection easy to use math functions
            0.0f, 
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt ); //only want to tilt on z axis
    }
    
}
[System.Serializable]
public class Boundary //unknown to unity not cerealized. to let unity view in inspector need to cerealize
{
    public float xMin, xMax, zMin, zMax;
}