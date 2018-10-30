using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_motion : MonoBehaviour {

	public int player_id;
	public float cam_sensitivity;
	public Animator anim;
	public Transform Camera_transform;
	private float hor_move, ver_move, hor_cam, ver_cam, hor_dpad, ver_dpad, l_trigger, r_trigger;
	public bool on_ground, sprinting, crouching;
	private int weapon;
	public GameObject Parent_container;
	public Transform Head_transform;
	private bool lock_cam;
	private float cam_rotX;

	// Use this for initialization
	void Start () {
		weapon = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
 		//"Range" inputs
 		hor_move = Input.GetAxis("Hor_move_" + player_id);
 		ver_move = Input.GetAxis("Ver_move_" + player_id);
 		hor_cam = Input.GetAxis("Hor_cam_" + player_id);
 		ver_cam = Input.GetAxis("Ver_cam_" + player_id);
 		hor_dpad = Input.GetAxis("Hor_dpad_" + player_id);
 		ver_dpad = Input.GetAxis("Ver_dpad_" + player_id);
 		l_trigger = Input.GetAxis("L_trigger_" + player_id);
 		r_trigger = Input.GetAxis("R_trigger_" + player_id);

		anim.SetFloat("Forward_direction", ver_move);
		anim.SetFloat("Side_direction", hor_move);

		transform.rotation = Parent_container.transform.rotation;
		transform.position = Parent_container.transform.position;

		Camera_transform.position = Head_transform.position;

		//Control camera
		if(ver_cam != 0)
		{
			/*if(Camera_transform.localEulerAngles.x < 90.0f && Camera_transform.localEulerAngles.x > -90.0f)
			{
				Camera_transform.Rotate(Vector3.right * cam_sensitivity * ver_cam * Time.deltaTime* 150);
			}else if(Camera_transform.rotation.eulerAngles.x < 0)
			{
				//Camera_transform.rotation = Quaternion.Euler(89.5f, 0.0f, 0.0f);
			}else if(Camera_transform.rotation.eulerAngles.x > 0)
			{
				//Camera_transform.rotation = Quaternion.Euler(-89.5f, 0.0f, 0.0f);
			}*/

			
			 

				cam_rotX += cam_sensitivity * ver_cam * Time.deltaTime* 150;
			    cam_rotX = Mathf.Clamp (cam_rotX, -70, 30);
			             
			    Camera_transform.localEulerAngles = new Vector3(cam_rotX, Camera_transform.localEulerAngles.y, Camera_transform.localEulerAngles.z);
		}

		//Jump
    	if(on_ground){
    		if(Input.GetButtonDown("A_btn_" + player_id))
			{
				anim.SetTrigger("Jump");
			}
    	}

    	//Sprint
		if(sprinting)
		{
			anim.SetFloat("Run", 1.0f);
		}else
		{
			anim.SetFloat("Run", 0.0f);
		}

    	//Crouch
		if(crouching)
		{
			anim.SetFloat("Crouch", 1.0f);
			anim.SetFloat("Run", 0.1f);
		}else
		{
			anim.SetFloat("Crouch", 0.0f);
			anim.SetFloat("Run", 0.0f);
		}
    	

    	//Back button action
    	if(on_ground)
    	{
    		if(Input.GetButtonDown("Back_btn_" + player_id))
    		{
    			anim.SetTrigger("Squat");
    		}
    	}

    	//Pick_up
    	if(on_ground)
    	{
    		if(Input.GetButtonDown("X_btn_" + player_id))
    		{
    			anim.SetTrigger("Pick_up");
    		}
    	}

    	//Throw
		if(ver_dpad < -0.9f)
		{
			anim.SetTrigger("Drop");
		}

    	//Change weapon
		if(Input.GetButtonDown("Y_btn_" + player_id))
		{
			weapon++;
			if(weapon > 2)
			{
				weapon = 0;
			}
			anim.SetInteger("Weapon", weapon);
			anim.SetTrigger("Change_wpn");
		}

		//Roll
    	if(on_ground)
    	{
    		if(Input.GetButtonDown("LB_btn_" + player_id))
    		{
    			anim.SetTrigger("Roll");
    		}
    	}

    	//Grenade
		if(Input.GetButtonDown("RB_btn_" + player_id))
		{
			anim.SetTrigger("Grenade");
		}

		//Shoot
		if(r_trigger > 0.4f)
		{
			anim.SetBool("Shooting", true);
		}else
		{
			anim.SetBool("Shooting", false);
		}

		//Reload
		if(Input.GetButtonDown("B_btn_" + player_id))
		{
			anim.SetTrigger("Reload");
		}

		//Dead
		if(Input.GetButtonDown("Start_btn_" + player_id))
		{
			anim.SetTrigger("Dead");
		}


		// Lock camera
		if(!lock_cam)
		{
			Parent_container.GetComponent<Character_movement>().lock_cam = false;
		}

		//Release camera
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Picking Up") 
			|| anim.GetCurrentAnimatorStateInfo(0).IsName("Air Squat Bent Arms")
			|| anim.GetCurrentAnimatorStateInfo(0).IsName("Sword And Shield Death")
			|| anim.GetCurrentAnimatorStateInfo(0).IsName("Quick Roll To Run"))
		{
			Parent_container.GetComponent<Character_movement>().lock_cam = true;
			lock_cam = true;
		}else
		{
			lock_cam = false;
		}


	}

}
