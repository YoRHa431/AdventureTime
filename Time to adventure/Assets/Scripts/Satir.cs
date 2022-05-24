using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satir : Entity
{
    private Animator anim;
    private Collider2D col;
    private ScoreManager sm;

    private void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        sm = FindObjectOfType<ScoreManager>();
        lives = 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (lives > 0 && collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
            lives--;
            Debug.Log($"у сатира {lives} хп");
        }

        if (lives < 1)
            Die();
    }
    public override void Die()
    {
        col.isTrigger = true;
        anim.SetTrigger("Death");
        sm.kill();
    }
}
