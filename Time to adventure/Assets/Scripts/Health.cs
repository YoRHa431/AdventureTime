//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Health : Entity
//{
//    private Animator anim;
//    private Collider2D col;
//    private ScoreManager sm;
//    public void Start()
//    {
//        sm = FindObjectOfType<ScoreManager>();
//        col = GetComponent<Collider2D>();
//        lives = 2;
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (lives > 0 && collision.gameObject == Hero.Instance.gameObject)
//        {
//            Hero.Instance.GetDamage();
//            lives--;
//            Debug.Log($"{lives} υο");
//        }

//        if (lives < 1)
//        {
//            Die();
//        }
//    }
//    public override void Die()
//    {
//        col.isTrigger = true;
//        anim.SetTrigger("die");
//        sm.kill();
//    }
//}

