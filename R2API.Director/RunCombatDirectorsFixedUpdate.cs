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
        _currentStageCombatDirectorsHashSet.Clear();
        combatDirectors = GetComponents<CombatDirector>();
        if (combatDirectors == null) return;
        foreach (CombatDirector combatDirector in combatDirectors) _currentStageCombatDirectorsHashSet.Add(combatDirector);
    }
    public void FixedUpdate()
    {
        if (combatDirectors == null) return;
        for (int i = 0; i < _allCombatDirectors.Count; i++)
        {
            CombatDirector combatDirector = _allCombatDirectors[i];
            if (!combatDirector)
            {
                _allCombatDirectors.RemoveAt(i);
                continue;
            }
            if (!HandleCombatDirectorActivity(combatDirector)) continue;
            combatDirector.FixedUpdate();
        }
    }
}
