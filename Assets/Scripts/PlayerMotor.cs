using UnityEngine;
using UnityEngine.InputSystem;



    public class PlayerMotor : MonoBehaviour
    {
        private CharacterController controller;
        private Vector3 playerVelocity;
        public float speed = 5f;
        public bool shoot;





        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {


        }
        //gets the inputs for the InputManager and applies them to the char controller
        public void ProcessMove(Vector2 input)
        {
            Vector3 moveDirection = Vector3.zero;
            moveDirection.x = input.x;
            moveDirection.z = input.y;
            controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        }

        public void OnShoot(InputValue value)
        {
            shoot = value.isPressed;
        }

    }

