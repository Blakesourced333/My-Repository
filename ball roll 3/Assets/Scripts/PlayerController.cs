using UnityEngine;
using System.Collections;
using System;
public class PlayerController : MonoBehaviour 
{
	public float speed;
	public GUIText countText;
	public GUIText countdownText;
	public GUIText winText;
	private int count;
	private DateTime starttime;
	private DateTime endtime;
	private TimeSpan Timelimit = 
		new TimeSpan( 0, 2, 0 );
	void Start ()
	{
		count = 0; 
		starttime = DateTime.Now;

		SetCountText ();
		winText.text = "";
		}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float moveJump = Input.GetAxis ("Fire1");

		Vector3 movement = new Vector3(moveHorizontal,moveJump ,moveVertical);

		rigidbody.AddForce(movement * speed * Time.deltaTime);
		DateTime currenttime = DateTime.Now;
		TimeSpan timetaken = currenttime - starttime;
		TimeSpan timeleft = Timelimit - timetaken;
		countdownText.text = timeleft.ToString ();
		}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "PickUp") 
		{
			other.gameObject.SetActive(false);
			count = count +1;
			 SetCountText ();
		}
    }

	void SetCountText ()
	{
		countText.text = "Count:" + count.ToString ();
		if (count >= 8) 
		{
			endtime = DateTime.Now;
		TimeSpan timetaken = endtime - starttime;

			Console.Write(timetaken.ToString());      

		
			if (timetaken > Timelimit)
			{
				winText.text = "YOU LOSE........";
			}
			else 
			{
				winText.text = "YOU WIN!";
			}

				}
		}
}