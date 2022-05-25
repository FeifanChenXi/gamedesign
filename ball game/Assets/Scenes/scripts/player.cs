using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{ 
public float speed;
private Rigidbody rb;
public Text countText;
public Text winText;
public AudioSource triggerAudio;

private int count;
void Start (){
    rb=GetComponent<Rigidbody>();
    count=0;
  SetCountText();
  winText.text="";
}
void FixedUpdate (){
    float moveHorizontal=Input.GetAxis("Horizontal");
    float moveVertical=Input.GetAxis("Vertical");

    Vector3 movement= new Vector3 (moveHorizontal,0.0f,moveVertical);
    rb.AddForce(movement*speed);

}
void OnTriggerEnter(Collider other){
    if(other.gameObject.CompareTag("pick up")){
        other.gameObject.SetActive(false);
        count=count+1;
          SetCountText();
            triggerAudio.Play();
            getbigger();
            getslower();
    }
      if(other.gameObject.CompareTag("white")){
        other.gameObject.SetActive(false);
        count=count-1;
          SetCountText();
          triggerAudio.Play();
          getsmaller();
          getfaster();
    }
}
void getbigger(){
    transform.localScale+=new Vector3(0.1f,0.1f,0.1f);
}
void getsmaller(){
    transform.localScale-=new Vector3(0.1f,0.1f,0.1f);
}
void getfaster(){
    // gameObject.GetComponent<Rigidbody>().velocity=new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x+1,gameObject.GetComponent<Rigidbody>().velocity.y+1,0);
    speed=speed+10;
     float moveHorizontal=Input.GetAxis("Horizontal");
    float moveVertical=Input.GetAxis("Vertical");

    Vector3 movement= new Vector3 (moveHorizontal,0.0f,moveVertical);
    rb.AddForce(movement*speed);
}
void getslower(){
    // gameObject.GetComponent<Rigidbody>().velocity=new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x-1,gameObject.GetComponent<Rigidbody>().velocity.y-1,0);
        speed=speed-1;
         float moveHorizontal=Input.GetAxis("Horizontal");
    float moveVertical=Input.GetAxis("Vertical");

    Vector3 movement= new Vector3 (moveHorizontal,0.0f,moveVertical);
    rb.AddForce(movement*speed);
}

void SetCountText(){
  countText.text="Count:"+count.ToString();
  if(count>=6){
        winText.text="help black Win";
}
  if(count<=-6){
        winText.text="help white Win";
}
}
}