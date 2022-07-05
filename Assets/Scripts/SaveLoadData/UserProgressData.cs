using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserProgressData
{
    //public bool[] locklevel = { false, true, true };

    public bool[] jawabanBenarDarat = { false, false, false };
    public bool[] jawabanBenarAir = { false, false, false };
    public bool[] jawabanBenarUdara = { false, false, false };

    public bool[] lockArsipDarat = { true, true, true};
    public bool[] lockArsipAir = { true, true, true };
    public bool[] lockArsipUdara = { true, true, true };

    public bool musicON = true;
    public bool musicOFF = false;
}
