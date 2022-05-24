using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int HP;
    public int damage;

    private Transform player;
    private Animator anim;

    public Transform attackPos;
    public LayerMask layerMask;
    public float attackRange;

    public float recharge;
    public float startRecharge;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();

        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        recharge += Time.deltaTime;

        anim.SetBool("Run", true);

        if(HP <=0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(recharge >= startRecharge)
        {
            if(other.CompareTag("Player"))
            {
                anim.SetBool("Attack", true);
                recharge = 0;
            }
        }
        else
        {

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    private void OnAttack()
    {
        Collider2D[] playerCollider = Physics2D.OverlapCircleAll(attackPos.position, attackRange, layerMask);
        anim.SetBool("Attack", false);
        for (int i = 0; i < playerCollider.Length; i++)
        {
            playerCollider[i].GetComponent<Hero>().GetDamage();
        }
    }

    public void TakeDamage()
    {
        HP -= damage;
    }
}
