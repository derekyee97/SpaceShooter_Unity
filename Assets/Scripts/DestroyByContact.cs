using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
   private GameController gameController;
    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController==null) //insurance policy
        {
            Debug.Log("Cannot find  'GameController' script ");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag=="boundary")   //want to ignore collision with boundary or else it will delete
        {
            return;
        }
        Instantiate(explosion, transform.position,transform.rotation);  //handles explosion with bolt and asteroid 
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation); //handles explosion with ship and asteroid
            gameController.GameOver();
               
        }
        // Debug.Log(other.name);  //prints gameobject that other is attached to
        gameController.AddScore(scoreValue); //addresses instance of class 
        Destroy(other.gameObject); //destroy bolt when hit asteroid 
        Destroy(gameObject); //destroy game object script attached to, all children, and all components. destroy marks to be destroyed, all destroyed at end of frame. so order dont matter

       
      
                                
    }

}
