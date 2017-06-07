using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public List<Skill> m_passives;
    public List<Skill> m_actives;

    [SerializeField] private GameObject m_actionBar;
    [SerializeField] private GameObject m_passiveBar;


    public void NewSkill(Skill skill)
    {
        if (skill.m_activeSkill)        
            newActive(skill);
        else newPassive(skill);        
    }

    private void newActive(Skill skill)
    {
        m_actives.Add(skill);
    }

    private void newPassive(Skill skill)
    {
        m_passives.Add(skill);
    }
}
