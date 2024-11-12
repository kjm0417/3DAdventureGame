using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackStrategy
{
    void Attack(int power); 
   
}

public class WeaponManager : MonoBehaviour
{
    private IAttackStrategy _strategy;

    public void SetAttackStrategy(IAttackStrategy strategy)
    {
        _strategy = strategy;
    }

    public void PerformAttack(int power)
    {
        _strategy.Attack(power);
    }

}
