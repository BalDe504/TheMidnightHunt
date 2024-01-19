using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class KeyInventory : MonoBehaviour
    {
        public bool hasFirstKey = false;
        public bool hasSecondKey = false;

        public bool hasLighter = false;

        public bool enemyTriggered = false;

    //zliczanie podniesionych notatek
        public int NotesPicked = 0;

    //czy podniesiona notatka
        public bool Note1 = false;
        public bool Note2 = false;
        public bool Note3 = false;
        public bool Note4 = false;
        public bool Note5 = false;
        public bool Note6 = false;
        public bool Note7 = false;

    //czas na podniesienie klucza
        public string firstKeyTime;
        public string secondKeyTime;
}


