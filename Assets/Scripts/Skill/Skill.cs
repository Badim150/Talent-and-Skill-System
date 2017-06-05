using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour {

    [SerializeField]
    private SkillTree m_skillTree;  //Pointer to the Skill Tree

    public string m_name;           //Name of the Skill    
    public string m_description;    //Summary of what the player will gain by acquiring this skill  
    public Sprite m_icon;           //Icon of the skill

    public bool m_learned;          //Has this skill been aquired?
    public bool m_newAbility;       //Is this a new ability or an upgrade?
    public int m_tier;              //Which tier of the talent tree this skill belongs

    public List<Skill> m_childOf;   //List of skills required to learn this skill
    private Ability m_effect;    

/// <summary>
/// Checks if this skill can be learned or not. 
/// Returns True if yes, False otherwise.
/// </summary>
/// <returns></returns>
    public bool CanBeLearned()
    {
        if (m_learned || m_skillTree.m_currentTier < m_tier) return false;

        for (int i = 0; i < m_childOf.Count; i++)        
            if (!m_childOf[i].m_learned) return false;

        return true;        
    }

    /// <summary>
    /// Called to learn the skill. 
    /// If the skill is an Active SKill, adds it to the player's skil list.
    /// If the skill is a Passive Skill, applies its effects on the Player.
    /// </summary>
    public void LearnSkill()
    {
        m_learned = true;        
        m_effect.Learn();
    }
}
