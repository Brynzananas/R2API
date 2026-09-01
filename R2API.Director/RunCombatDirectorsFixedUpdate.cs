using RoR2;
using RoR2BepInExPack.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static R2API.DirectorAPI;

namespace R2API;
public class RunCombatDirectorsFixedUpdate : MonoBehaviour
{
    public CombatDirector[] combatDirectors;
    public void Awake()
    {
        currentStageCombatDirectorsHashSet.Clear();
        combatDirectors = GetComponents<CombatDirector>();
        if (combatDirectors == null) return;
        foreach (CombatDirector combatDirector in combatDirectors) currentStageCombatDirectorsHashSet.Add(combatDirector);
    }
    public void FixedUpdate()
    {
        foreach (CombatDirector combatDirector in combatDirectors)
        {
            if (!combatDirector || !HandleCombatDirectorActivity(combatDirector)) continue;
            combatDirector.FixedUpdate();
        }
    }
}
