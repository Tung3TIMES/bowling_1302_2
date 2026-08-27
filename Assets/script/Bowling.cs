using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Bowling : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private int forcePower;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            ShootBall();

        if (Keyboard.current.rightArrowKey.isPressed)
            MoveRight();

        if (Keyboard.current.leftArrowKey.isPressed)
            MoveLeft();

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            RestartGame();
        }
    }

    public void ShootBall()
    {
        rb.AddForce(Vector3.forward * forcePower, ForceMode.Impulse);
    }

    private void MoveRight()
    {
        transform.position += new Vector3(2f, 0f, 0f) * Time.deltaTime;
    }

    private void MoveLeft()
    {
        transform.position += new Vector3(-2f, 0f, 0f) * Time.deltaTime;
    }

    public void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}