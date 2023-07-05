using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryStat : StatusEffect
{
        public TemporaryStat(float duration, int physicalarmor = 0, int magicarmor = 0, int physicaldamage = 0, int newHealth = 0)
        {
            addedPhysicalArmor = physicalarmor;
            addedMagicArmor = magicarmor;
            addedHealth = newHealth;
            
            _duration = duration;
        }

        private int addedPhysicalArmor;
        private int addedMagicArmor;
        private int addedHealth;
        private int addedPhysicalDamage;

        public override void ApplyEffect()
        {
            _entity.TempPhysicalArmor += addedPhysicalArmor;
            _entity.TempMagicArmor += addedMagicArmor;

            _entity.TempPhysicalDamage += addedPhysicalDamage;

            _entity.TempHealth += addedHealth;
            _entity.CurrentHealth += addedHealth;

            _entity.CheckOverHealthThreshold();
        }

        public override void UpdateEffect()
        {
            _duration -= Time.time;

            CheckEffectCondition();
        }

        public override void CheckEffectCondition()
        {
            if (_duration < 0)
            {
                _entity.TempPhysicalArmor -= addedPhysicalArmor;
                _entity.TempMagicArmor -= addedMagicArmor;
                _entity.TempHealth -= addedHealth;

                _entity.CheckOverHealthThreshold();

                IsEnded = true;
            }
        }
    }