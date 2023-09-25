using UnityEngine;
using UnityEngine.UI;
using CodeBase.Combat.Attacks;
using System.Collections.Generic;

namespace CodeBase.Combat.Player
{
    public class PlayerController : MonoBehaviour
    {
        public BaseAttack baseAttack;
        public Button attackButton;

        public void Start()
        {
            baseAttack.enemyTags = new List<string>();
            baseAttack.enemyTags.Add("Enemy");
            attackButton.onClick.AddListener(() => baseAttack.PerformAttack());
        }
    }
}