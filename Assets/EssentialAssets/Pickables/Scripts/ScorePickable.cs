using System;
using UnityEngine;

namespace Pickable
{
    public class ScorePickable: Pickable
    {
        [SerializeField] private int pointsAmount;

        public static event Action PickedUp;
        protected override void PickingBehaviour()
        {
            PickedUp?.Invoke();
            base.PickingBehaviour();
        }
    }
}