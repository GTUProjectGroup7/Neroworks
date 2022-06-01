using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isMoveable;
    private bool isMovingForward;
    private bool isMovingBack;
    private bool isTurningRight;
    private bool isTurningLeft;

    private CharacterController _charController;
    private Vector3 v_movement;
    private Vector3 v_velocity;
    private float moveSpeed;

    Rigidbody rb;

    private void Start()
    {
        isMoveable = true;
        //rb = GetComponent<Rigidbody>();
        _charController = GetComponent<CharacterController>();
        moveSpeed = 250;
        v_velocity.y = 0f;
    }

    private void Update()
    {
        if (isMoveable && Input.GetKey(KeyCode.UpArrow))
        {
            isMovingForward = true;
            isMovingBack = false;
            isTurningRight = false;
            isTurningLeft = false;
            StartCoroutine("wait");
        }
        else if (isMoveable && Input.GetKey(KeyCode.DownArrow))
        {
            isMovingForward = false;
            isMovingBack = true;
            isTurningRight = false;
            isTurningLeft = false;
            StartCoroutine("wait");
        }
        else if (isMoveable && Input.GetKey(KeyCode.RightArrow))
        {
            isMovingForward = false;
            isMovingBack = false;
            isTurningRight = true;
            isTurningLeft = false;
            StartCoroutine("wait");
        }
        else if (isMoveable && Input.GetKey(KeyCode.LeftArrow))
        {
            isMovingForward = false;
            isMovingBack = false;
            isTurningRight = false;
            isTurningLeft = true;
            StartCoroutine("wait");
        }
    }

    void FixedUpdate()
    {       
        if (isMovingForward)
        {
            //transform.position += new Vector3(0f, 0f, speed);
            //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
            v_movement = _charController.transform.forward;
            _charController.Move(v_movement * moveSpeed * Time.deltaTime);
            _charController.Move(v_velocity);
        }
        else if (isMovingBack)
        {
            //transform.position -= new Vector3(0f, 0f, speed);
            //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);
            v_movement = -1 * _charController.transform.forward;
            _charController.Move(v_movement * moveSpeed * Time.deltaTime);
            _charController.Move(v_velocity);
            _charController.Move(v_velocity);
        }
        else if (isTurningRight)
        {
            //Quaternion goal = Quaternion.AngleAxis(1f, new Vector3(0f, rotationSpeed, 0f));
            //transform.rotation = goal * transform.rotation;
            _charController.transform.Rotate(Vector3.up * 50 * Time.deltaTime);
            _charController.Move(v_velocity);
        }
        else if (isTurningLeft)
        {
            //transform.Rotate(new Vector3(0f, -rotationSpeed, 0f) * Time.deltaTime);
            _charController.transform.Rotate(-1 * Vector3.up * 50 * Time.deltaTime);
            _charController.Move(v_velocity);
        }

        //v_movement = _charController.transform.forward;
        //_charController.transform.Rotate(Vector3.up * 100 * Time.deltaTime);

        //_charController.Move(v_movement * moveSpeed * Time.deltaTime);

    }

    private IEnumerator wait()
    {
        isMoveable = false;
        yield return new WaitForSeconds(0.5f);
        isMoveable = true;
    }
 }
