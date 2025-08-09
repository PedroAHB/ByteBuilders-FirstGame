using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerBlackboard))]
public class Player : MonoBehaviour
{
    private PlayerStateMachine stateMachine;
    private PlayerBlackboard blackboard;

    private void Start()
    {
        blackboard = GetComponent<PlayerBlackboard>();
        stateMachine = new PlayerStateMachine(blackboard);
        stateMachine.Initialize(typeof(IdleState));
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        blackboard.CheckIfGrounded();
        blackboard.PlayerAnimator.SetBool("isGrounded", blackboard.IsGrounded);
        stateMachine.FixedUpdate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}