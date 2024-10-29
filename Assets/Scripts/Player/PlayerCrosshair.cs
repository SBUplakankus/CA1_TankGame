using UnityEngine;

namespace Player
{
    public class PlayerCrosshair : MonoBehaviour
    {
        public Camera cam;
        // Start is called before the first frame update
        void Start()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }

        // Update is called once per frame
        void Update()
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawLine (ray.origin, cam.transform.forward * 50000000, Color.red);
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;

        }
    }
}
