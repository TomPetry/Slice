using System.Collections;
using System.Collections.Generic;
using Master;
using Sword;
using UnityEngine;

public class DamagePower : MonoBehaviour,PowerUps
{
    private int _damage = 0;
    private int _level;
    
    public GameObject sword;

    
    public void addLevel()
    {
        MasterCounter masterCounter = GameObject.Find("GameMaster").GetComponent<MasterCounter>();
        _level++;
        _damage += 2;
        masterCounter.damageIncrease = _damage;
    }

    public void updateEffect()
    {
        throw new System.NotImplementedException();
    }

    public void setNewSword(GameObject updatedSword)
    {
        sword = updatedSword;
    }

    public void setLevel(int level)
    {
        for (int i = 0; i < level; i++)
        {
            addLevel();
        }
    }

    public int getLevel()
    {
        return _level;
    }
}
