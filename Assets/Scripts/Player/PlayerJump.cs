using System;
using System.Collections;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerJump : MonoBehaviour
    {
        [Header("Components")]
        public Rigidbody2D rb;
        private AbilitiesDisplay _abDisplay;
        
        [Header("Jump")]
        public float jumpPower;
        public float jumpCooldown;
        private bool _canJump;
        
        [Header("Dash")]
        public float dashPower;
        public float dashCooldown;
        private bool _canDash;

        private void Awake()
        {
            _abDisplay = GetComponent<AbilitiesDisplay>();
        }

        private void Start()
        {
            _canJump = true;
            _canDash = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canJump)
            {
                rb.AddForce(new Vector2(rb.velocity.x, jumpPower));
                StartCoroutine(ResetJump());
                _canJump = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && _canDash)
            {
                rb.AddForce(new Vector2(dashPower, rb.velocity.y));
                StartCoroutine(ResetDash());
                _canDash = false;
            }
            
        }
        
        private IEnumerator ResetDash()
        {
            _abDisplay.ResetDashSlider(dashCooldown);
            yield return new WaitForSeconds(dashCooldown);
            _canDash = true;
        }

        private IEnumerator ResetJump()
        {
            _abDisplay.ResetJumpSlider(jumpCooldown);
            yield return new WaitForSeconds(jumpCooldown);
            _canJump = true;
        }
    }
}