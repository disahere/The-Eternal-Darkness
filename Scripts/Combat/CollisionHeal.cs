using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHeal : MonoBehaviour
{
    public int collisionHeal = 10;
    public string collisionTag;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        //Если тег объекта коллайдер которого столкнулся с коллайдером нашего объекта - Player
        if (coll.gameObject.tag == collisionTag)
        {
            //Берём у этого объекта компонент Health (Скрипт который на нём висит)
            Health health = coll.gameObject.GetComponent<Health>();
            //И вызываем функцию получения урона, в агрументе переменная хила
            health.SetHealth(collisionHeal);
            //Уничтожаем хилку после использования
            Destroy(gameObject);
        }
    }
}
