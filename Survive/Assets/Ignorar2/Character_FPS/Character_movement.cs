using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_movement : MonoBehaviour {

	public int player_id;
	public float move_speed;
	public float sprint_speed;
	public float crouch_speed;
	public float cam_sensitivity;
	public float jump_force;
	private float crouch_multi;
	private float sprint_multi;
	public float max_move_speed;
	public Rigidbody body_rigid;
	public Transform GroundCheck;
	private float hor_move, ver_move, hor_cam;
	private Vector3 deaccel_hor, deaccel_ver;
	private bool on_ground, sprinting, crouching;
	public GameObject Player_model;
	public bool lock_cam;

	// Use this for initialization
	void Start () {
		sprint_multi = 1.0f;
		crouch_multi = 1.0f;

		Player_model.GetComponent<Character_motion>().player_id = player_id;
		Player_model.GetComponent<Character_motion>().cam_sensitivity = cam_sensitivity;
	}
	
	// Update is called once per frame
	void Update () 
	{
 		//"Range" inputs
 		hor_move = Input.GetAxis("Hor_move_" + player_id);
 		ver_move = Input.GetAxis("Ver_move_" + player_id);
 		hor_cam = Input.GetAxis("Hor_cam_" + player_id);

		deaccel_hor = transform.InverseTransformDirection(body_rigid.velocity);
		deaccel_ver = transform.InverseTransformDirection(body_rigid.velocity);

		//Ground check, makes on_ground true if player is touching ground.
		if(Physics.Raycast(GroundCheck.position, Vector3.down, 0.3f))
		{
			on_ground = true;
		}else
		{
			on_ground = false;
		}

		//Movement
		//Move sideways
		if(hor_move != 0 && on_ground)
		{
			//transform.Translate(Vector3.right * hor_move * sprint_multi * crouch_multi * Time.deltaTime * 4f);
			if((hor_move >0 && deaccel_hor.x < max_move_speed*sprint_multi * crouch_multi) || (hor_move <0 && deaccel_hor.x > (max_move_speed*sprint_multi * crouch_multi*-1)))
			{
				body_rigid.AddRelativeForce(Vector3.right * hor_move * sprint_multi * crouch_multi * 1000f);
			}
			//print(hor_move);
		}else if((deaccel_hor.x > 1 || deaccel_hor.x < -1)&& on_ground)
		{
			deaccel_hor.x *= 0.1f;
			if(deaccel_hor.x < 0.1f)
			{
				deaccel_hor.x *= 0f;
			}
			body_rigid.velocity = transform.TransformDirection(deaccel_hor);
		}
		//Move forward
		if(ver_move != 0 && on_ground)
		{
			//transform.Translate(Vector3.forward * ver_move * move_speed * sprint_multi * crouch_multi * Time.deltaTime * 4f);
			if((ver_move >0 && deaccel_ver.z < max_move_speed*sprint_multi * crouch_multi) || (ver_move <0 && deaccel_ver.z > (max_move_speed*sprint_multi * crouch_multi*-1)))
			{
				body_rigid.AddRelativeForce(Vector3.forward * ver_move * move_speed * sprint_multi * crouch_multi * 1000f);
			}
			//print(ver_move);
		}else if((deaccel_ver.z > 1 || deaccel_ver.z < -1) && on_ground)
		{
			deaccel_ver.z *= 0.1f;
			if(deaccel_ver.z < 0.1f)
			{
				deaccel_ver.z *= 0f;
			}
			body_rigid.velocity = transform.TransformDirection(deaccel_ver);
		}

		//Camera horizontal
		
		if(hor_cam != 0 && !lock_cam)
		{
			transform.Rotate(Vector3.up * cam_sensitivity * hor_cam * Time.deltaTime* 150);
		}

		//Jump
    	if(on_ground){
    		if(Input.GetButtonDown("A_btn_" + player_id))
			{
				body_rigid.AddRelativeForce(Vector3.up * jump_force *15000f);
			}
    	}

    	//Sprint
    	if(on_ground){
    		if(Input.GetButtonDown("LS_btn_" + player_id) && !sprinting)
			{
				sprinting = true;
				crouching = false;
				crouch_multi = 1.0f;
				sprint_multi = sprint_speed;
			}else if(Input.GetButtonDown("LS_btn_" + player_id))
			{
				sprinting = false;
				sprint_multi = 1.0f;
			}
    	}

    	//Crouch
		if(Input.GetButtonDown("RS_btn_" + player_id) && !crouching)
		{
			crouching = true;
			sprinting = false;
			sprint_multi = 1.0f;
			crouch_multi = crouch_speed;
		}else if(Input.GetButtonDown("RS_btn_" + player_id))
		{
			crouch_multi = 1.0f;
			crouching = false;
			body_rigid.AddRelativeForce(Vector3.up * 12000f);
		}
    	

		//Roll
    	if(on_ground)
    	{
    		if(Input.GetButtonDown("LB_btn_" + player_id))
    		{
    			body_rigid.AddRelativeForce(Vector3.up * jump_force * 10000f);
    			body_rigid.AddRelativeForce(Vector3.forward * sprint_multi * crouch_multi * 20000f);
    			transform.Rotate(Vector3.up * 3f);
    		}
    	}

    	Player_model.GetComponent<Character_motion>().on_ground = on_ground;
    	Player_model.GetComponent<Character_motion>().crouching = crouching;
    	Player_model.GetComponent<Character_motion>().sprinting = sprinting;

	}

}
