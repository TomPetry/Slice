using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PowerUps
{
    void addLevel();

    void updateEffect();

    void setNewSword(GameObject sword);

    void setLevel(int level);

    int getLevel();
}