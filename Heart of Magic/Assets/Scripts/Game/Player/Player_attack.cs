using UnityEngine;

public class Player_attack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] energyballs;
    [SerializeField] private GameObject[] bombsartilery;
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
        if( cooldownTimer >= attackCooldown && 0 <= FindEnergyballs() && 0<= FindBombs() && !FindObjectOfType<Player_movement>().isMoving())
        {
            switch (Input.inputString)
            {
                case "5":
                    Attack();
                    break;

                case "8":
                    Artilery();
                    break;
            }
            /*
            if(Input.GetKey(KeyCode.Keypad5))
            {
                Attack();
            }*/
        }
        cooldownTimer += Time.deltaTime;

    }
//------------------------------Energy ball
    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        //Pool fireballs
        energyballs[FindEnergyballs()].transform.position = firePoint.position;
        energyballs[FindEnergyballs()].GetComponent<Energy_fireball>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    //  Najde nejlepší energyball
    private int FindEnergyballs()
    {
        for(int i = 0; i < energyballs.Length; i++)
        {
            if(!energyballs[i].activeInHierarchy)
                return i;
        }
        return -1;  //  vrať hodnotu zápornou, jestliže nemá žádný volný energyball
    }
//------------------------------Bomb artilery
    private void Artilery()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        //Pool bombs
        bombsartilery[FindBombs()].transform.position = firePoint.position;
        bombsartilery[FindBombs()].GetComponent<Bomb_artilery>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    //  same
    private int FindBombs()
    {
        for(int i = 0; i < bombsartilery.Length; i++)
        {
            if(!bombsartilery[i].activeInHierarchy)
                return i;
        }
        return -1;  //  vrať hodnotu zápornou, jestliže nemá žádný volný energyball
    }
}
