﻿using UnityEngine;
using UnityEngine;
using System.Collections;
using System;

public class TouchInput : MonoBehaviour
{
	public float RotationSpeed = 10;
	public float ZoomSpeed = 0.001f;
	public float ZoomMin = 0.05f;
	public float ZoomMax = 0.5f;

	private Transform arCameraTransform;
	private float m_LastTouchDistance = -1;
	private bool m_ZoomStopped = true;

	// Use this for initialization
	void Start ()
	{
        arCameraTransform = GameObject.FindGameObjectWithTag("ARCamera").transform;
        Debug.Log("Ar camera is : " + arCameraTransform == null);
	}

	// Update is called once per frame
	void Update()
	{

		//if (Input.GetKeyDown(KeyCode.KeypadPlus))
		//	Zoom(0.1f);

		//if (Input.GetKeyDown(KeyCode.KeypadMinus))
		//	Zoom(-0.1f);
		//return;

		int touch_count = Input.touchCount;

		if (!m_ZoomStopped && touch_count == 0)
			m_ZoomStopped = true;


		if (touch_count <= 1 || touch_count > 2)
		{
			m_LastTouchDistance = -1.0f;
			return;
		}

		Vector2[] touch_pos;
		touch_pos = new Vector2[2];
		
		int index = 0;
		foreach (Touch touch in Input.touches)
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
			{
				touch_pos[index] = touch.position;
				index++;
			}


		if (index != 2)
		{
			m_LastTouchDistance = -1;
		}

		m_ZoomStopped = false;

		float distance = Vector2.Distance(touch_pos[0], touch_pos[1]);
		if (m_LastTouchDistance < 0)
		{
			m_LastTouchDistance = distance;
			return;
		}

		if (distance != m_LastTouchDistance)
		{
			Zoom(distance - m_LastTouchDistance);
			m_LastTouchDistance = distance;
		}
	}

	void OnMouseDrag()
	{
		if (Input.touchCount > 1)
			return;

		float rot_x = Input.GetAxis("Mouse X") * RotationSpeed * Mathf.Deg2Rad;
		float rot_y = Input.GetAxis("Mouse Y") * RotationSpeed * Mathf.Deg2Rad;

		//Camera cam = Camera.main;
		//Vector3 cam_right = cam.gameObject.transform.right;
		//Vector3 cam_up = cam.gameObject.transform.up;
		Vector3 cam_right = arCameraTransform.right;
		Vector3 cam_up = arCameraTransform.up;


		transform.RotateAround(cam_up, -rot_x );
		transform.RotateAround(cam_right, rot_y );
	}

	private void Zoom(float distance)
	{
		if (!m_ZoomStopped)
			return;

		float scale = distance * ZoomSpeed + transform.localScale.x;
		scale = Mathf.Clamp(scale, ZoomMin , ZoomMax);

		transform.localScale = new Vector3(scale, scale, scale);
	}
}
