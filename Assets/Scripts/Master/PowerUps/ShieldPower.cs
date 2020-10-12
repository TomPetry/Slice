using System.Collections;
using System.Collections.Generic;
using Master;
using UnityEngine;

public class ShieldPower : MonoBehaviour,PowerUps
{
    private int _level;
    
    public GameObject sword;

    
    public void addLevel()
    {
        MasterCounter master = GameObject.Find("GameMaster").GetComponent<MasterCounter>();
        _level++;

        master.shieldIncrease++;
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
