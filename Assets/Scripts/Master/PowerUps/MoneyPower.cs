using System.Collections;
using System.Collections.Generic;
using Master;
using UnityEngine;

public class MoneyPower : MonoBehaviour,PowerUps
{
    private int _money = 0;
    private int _level;
    
    public GameObject sword;

    
    public void addLevel()
    {
        _level++;
        GetComponent<MasterCounter>().addAmount += 0.2f;
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
