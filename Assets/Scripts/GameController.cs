using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SlotNamespace;

namespace GameControllerNamespace
{
    public class GameController
    {
        private SlotMachine slotMachine = new SlotMachine();

        public int[, ] Init()
        {
            return slotMachine.GetArray();
        }

        public int[, ] Run()
        {
            slotMachine.RunSlot();
            return slotMachine.GetArray();
        }

        public int[] Result()
        {
            slotMachine.CheckSlot();
            return slotMachine.GetResult();
        }
    }
}