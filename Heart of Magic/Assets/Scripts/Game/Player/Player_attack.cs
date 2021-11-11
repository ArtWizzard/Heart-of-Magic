using UnityEngine;

public class Player_attack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private Player_movement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<Player_movement>();
    }

    private void Update()
    { 
        if(Input.GetKey(KeyCode.Space) && cooldownTimer >= attackCooldown)
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        cooldownTimer = 0;
    }
}
