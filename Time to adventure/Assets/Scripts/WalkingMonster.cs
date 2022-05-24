using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMonster : Entity
{
    private float speed = 3.5f;
    private Vector3 dir;
    private SpriteRenderer sprite;
    private Animator anim;
    private Collider2D col;
    private ScoreManager sm;
    [SerializeField] private WalkingMonster walkingMonster;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        walkingMonster = GetComponent<WalkingMonster>();
        dir = transform.right;
        sm = FindObjectOfType<ScoreManager>();
        lives = 3;
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll
            (transform.position + transform.up * 0.1f + transform.right * dir.x * 1f, -0.1f);

        if (colliders.Length > 0) dir *= -1f;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(lives > 0 && collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
        }
        if (lives < 1)
            Die();
    }
    public override void Die()
    {
        col.isTrigger = true;
        walkingMonster.enabled = false;
        anim.SetTrigger("Death");
        sm.kill();
    }

}
