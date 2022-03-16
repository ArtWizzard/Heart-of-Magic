using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_rain : MonoBehaviour
{
    [Header ("Turret Holder")]
    [SerializeField] private GameObject[] turrets;

    [Header ("Duration")]
    [SerializeField] private float maxTime;
    [SerializeField] private float minTime;
    private float duration;
    private float actualTime;

    [Header ("Weakness")]
    [SerializeField] private GameObject mainBody;

    private SpriteRenderer pic;

    public bool active;

    private void Awake()
    {
        actualTime = 0;
        active = false;

        pic = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (active)
        {
            if (actualTime >= duration)
            {
                SetTurrets(false);
                ReturnStop();
                active = false;
            }
            actualTime += Time.deltaTime;
        }
    }

    public void SetRain()
    {
        gameObject.GetComponent<Boss_movement>().FreezeMovement(true);
        actualTime = 0;
        duration = Random.Range(minTime, maxTime);
        active = true;
        pic.color = new Color(1f, 0.5f, 0.5f, 1);
        mainBody.GetComponent<Boss_health>().multiplier = 2;
        SetTurrets(true);
    }

    private void SetTurrets(bool _state)
    {
        for (int i = 0; i < turrets.Length; i ++)
        {
            turrets[i].SetActive(_state);

            if (_state == true)
            {
                turrets[i].GetComponent<TurretProjectileResetter>().ResetProjectiles();
            }
        }
    }

    private void ReturnStop()
    {
        pic.color = Color.white;
        mainBody.GetComponent<Boss_health>().multiplier = 1;
        gameObject.GetComponent<Boss_movement>().FreezeMovement(false);
        gameObject.GetComponent<Boss_controller>().SetNext(true);
    }
}
