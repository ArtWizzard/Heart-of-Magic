using UnityEngine;

public class Player_attack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] energyballs;
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
        if(Input.GetKey( KeyCode.Space) && cooldownTimer >= attackCooldown)
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        // anim.SetTrigger("Attack");
        cooldownTimer = 0;

        //Pool fireballs
        energyballs[FindEnergyballs()].transform.position = firePoint.position;
        energyballs[FindEnergyballs()].GetComponent<Energy_fireball>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindEnergyballs()
    {
        for(int i = 0; i < energyballs.Length; i++)
        {
            if(!energyballs[i].activeInHierarchy)
                return i;
        }

        return 0;
    }
}
