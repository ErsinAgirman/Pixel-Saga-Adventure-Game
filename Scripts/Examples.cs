using UnityEngine;

// I used color in unity to make breakable floors. in rgba, a component for using opacity

public class Examples : MonoBehaviour
{

 private void Update()
{    
    if (isPlayerOnGround && !isBroken)
     {
          float elapsedTime = Time.time - startTime;

          float t = elaspedTime / timeToBreak;
          Color newcolor = new Color (1f, 1f, 1f, Mathf.Lerp(1f, 0F, t));
          spriteRenderer.color = newColor;

          if(elapsedTime >= timeToBreak)
          {
           BreakGround();
          }

 }
// with time opacity moves to 0 from 255 and looks like destroyed.
// other necessary actions made in BreakGround() method.


 gameObject.SetActive(false); //or
 gameObect.SetActive(true);
// if we need to destroy the item and recreate it later ve can use SetActive method;


Invoke("RespawnGround", respawnDelay);
// if we do this after a certain time We can use Invoke method.
// takes two variables (String,int) method name, and time

void RespawnGrond()
     {
         transform.position = initialPosition;
         spriteRenderer.color = Color.white; //255 = white
         isBroken = false;
         isPlayerOnGround = false;
         gameObject.SetActive(true);
     }
// For reset variables to Respawn again the object.














}
