using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerRol playerRol;
    public float speedMovement;
    private Vector2 screenBounds;
    private float objectHeight;
    void Start()
    {
        objectHeight = 1.0f;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        if (playerRol.Equals(PlayerRol.PlayerOne))
        {
            if (Input.GetKey("w"))
            {
                transform.Translate(Vector3.up * speedMovement * Time.deltaTime, Space.World);
            }
            else if (Input.GetKey("s"))
            {
                transform.Translate(Vector3.down * speedMovement * Time.deltaTime, Space.World);
            }
        }

        if (playerRol.Equals(PlayerRol.PlayerTwo))
        {
            if (Input.GetKey("up"))
            {
                transform.Translate(Vector3.up * speedMovement * Time.deltaTime, Space.World);
            }
            else if (Input.GetKey("down"))
            {
                transform.Translate(Vector3.down * speedMovement * Time.deltaTime, Space.World);
            }
        }
    }
    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}

public enum PlayerRol
{
    PlayerOne,
    PlayerTwo
}
