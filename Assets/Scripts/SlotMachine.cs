using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotNamespace
{
    public class SlotMachine
    {
        private const int NUM_COLUMN = 3;
        private const int NUM_CLASSES = 6;
        private const int LOSE = 6;
        private int[, ] slotArray = new int[NUM_COLUMN, NUM_CLASSES];
        private int[] slotResult = new int[NUM_CLASSES];
        private Dictionary<string, int> hashMap = new Dictionary<string, int>()
        {
            {"000", 0},
            {"111", 1},
            {"222", 2},
            {"333", 3},
            {"444", 4},
            {"555", 5},
        };

        public SlotMachine()
        {
            InitSlot();
            CheckSlot();
        }

        private void InitArray()
        {
            int[, ] array = slotArray;

            for (int i = 0; i < NUM_COLUMN; i++)
            {
                for (int j = 0; j < NUM_CLASSES; j++)
                {
                    array[i, j] = j;
                }
            }
        }

        private void InitSlot()
        {
            InitArray();
        }

        public int[, ] GetArray()
        {
            return slotArray;
        }

        public int[] GetResult()
        {
            return slotResult;
        }

        private void Shuffle()
        {
            int temp, idx;
            int[, ] array = slotArray;
            for (int i = 0; i < NUM_COLUMN; i++)
            {
                for (int j = NUM_CLASSES; j > 1; j--)
                {                    
                    idx = Random.Range(0, j);
                    temp = array[i, j-1];
                    array[i, j-1] = array[i, idx];
                    array[i, idx] = temp;
                }
            }                
        }

        public void RunSlot()
        {
            Shuffle();
        }

        private void Check()
        {
            string key;
            for (int i = 0; i < NUM_CLASSES; i++)
            {
                key = "";
                for (int j = 0; j < NUM_COLUMN; j++)
                {
                    key += slotArray[j, i].ToString();
                }
                if (hashMap.ContainsKey(key))
                {
                    slotResult[i] = hashMap[key];
                }
                else
                {
                    slotResult[i] = LOSE;
                }
            }
        }

        public void CheckSlot()
        {
            Check();
        }
    }
}