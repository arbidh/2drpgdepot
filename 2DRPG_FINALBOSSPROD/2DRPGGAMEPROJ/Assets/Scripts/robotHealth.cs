using UnityEngine;
using System.Collections;

public class robotHealth : MonoBehaviour {

	public int health = 100;
	public AudioClip[] hurtClip;
	public float hurtForce;
	public int damageAmount=5;
	public float repeatDamagePeriod=2f;

	public SpriteRenderer[] healthBar;
	private float lastHitTime;
	private Vector3 healthScale;
	private PlayerControl playercontrol;
	private Animator anim;





	void Awake()
	{
		playercontrol = GetComponent<PlayerControl> ();
		anim = GetComponent<Animator> ();
		//testWhatRenderer ("h100");


	}

	void Update()
	{



	}


	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == "Enemy") 
		{

		  if (Time.time > lastHitTime + repeatDamagePeriod) 
			{

				if (health > 0f) 
				{

					TakeDamage (col.transform);
					lastHitTime = Time.time;
				} 
				else 
				{

					GetComponent<PlayerControl> ().enabled = false;
					anim.SetTrigger ("Die");


				}



			}

		}


	}

	void TakeDamage(Transform enemy)
	{


		playercontrol.jump = false;

		Vector3 hurtVector = transform.position - enemy.position + Vector3.up * 5f;

		rigidbody2D.AddForce (hurtVector * hurtForce);

		health -= damageAmount;

		UpdateHealthBar ();

		//play a hurt clip
		//AudioSource.PlayClipAtPoint (hurtClip, transform.position);




	}

	void OnGUI()
	{

		UpdateHealthBar ();

	}



	public void UpdateHealthBar()
	{
		Debug.Log (health);
//		healthBar.transform.localScale = new Vector3 (healthScale.x * health * 0.01f, 1, 1);

	switch(health)
		{

			case 80:
			{
			   
			testWhatRenderer("h80");

			}
				break;
			case 85:
			{
			testWhatRenderer("h85");
				
			}
				break;
			
			case 90:
			{
			testWhatRenderer("h90");
				
			}
				break;
			
			case 95:
			{
			testWhatRenderer("h95");
				
			}
			break;
		    case 100:
		   {

			testWhatRenderer("h100");

		    }
		  		break;

			 default:
			{
			testWhatRenderer("default");
				break;


			}

		}

	}
	void testWhatRenderer(string tagname)
	{


		foreach(SpriteRenderer rend in healthBar)
		{

			if(rend.gameObject.tag == tagname)
			{
				rend.renderer.enabled=true;
				rend.transform.position=new Vector3(Camera.main.transform.position.x-10, Camera.main.transform.position.y+8,0);
				rend.sortingLayerName="UI";
			}
			else
			{
				rend.renderer.enabled=false;
			}

		}



	}


}



