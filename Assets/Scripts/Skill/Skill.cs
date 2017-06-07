using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour {

    public SkillTree m_skillTree;  //Pointer to the Skill Tree

    public string m_name;           //Name of the Skill    
    public string m_description;    //Summary of what the player will gain by acquiring this skill  
    public Sprite m_icon;           //Icon of the skill
    public bool m_activeSkill;      //Is this a new ability or an upgrade?
    public int m_tier;              //Which tier of the talent tree this skill belongs

    public List<Skill> m_childOf = null;   //List of skills required to learn this skill

    /// <summary>
    /// Checks if this skill can be learned or not. 
    /// Returns True if yes, False otherwise.
    /// </summary>
    /// <returns></returns>
    public bool CanBeLearned()
    {
        if (m_skillTree.KnowsSkill(this)) return false;

        if (m_childOf.Count  < 1) return true;

        for (int i = 0; i < m_childOf.Count; i++)
        {
            if (!m_skillTree.KnowsSkill(m_childOf[i])) return false;
        }

        return true;        
    }

    /// <summary>
    /// Called to learn the skill. 
    /// If the skill is an Active SKill, adds it to the player's skil list.
    /// If the skill is a Passive Skill, applies its effects on the Player.
    /// </summary>
    public virtual void LearnSkill()
    {
        m_skillTree.LearnSkill(this);
    }

    /// <summary>
    /// Only usable by Avctive skills.
    /// Called when the Player uses the Skill.
    /// </summary>
    public virtual void OnUse()
    {
        if (!m_activeSkill) return;       
    }

}
