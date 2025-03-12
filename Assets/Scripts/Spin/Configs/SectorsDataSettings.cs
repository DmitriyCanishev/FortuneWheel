using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Spin.Type;
using UnityEngine;

namespace Spin.Configs
{
    [CreateAssetMenu(menuName = "Configs/Spin/SectorsDataSettings", fileName = "SpinSectorsDataSettings")]
    public class SectorsDataSettings : ScriptableObject, IReadOnlyList<SectorsDataSettings.SectorDataSetting>
    {
        [Space(3), SerializeField] private List<SectorDataSetting> _sectorsSettings = null;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<SectorDataSetting> GetEnumerator() => _sectorsSettings.GetEnumerator();

        public int Count => _sectorsSettings.Count;

        public SectorDataSetting this[int index] => _sectorsSettings[index];

        public IReadOnlyList<float> GetSectorsValues() => 
            _sectorsSettings.Select(sector => sector.Value).ToList();

        public IReadOnlyList<float> GetSectorsProbability() => 
            _sectorsSettings.Select(sector => sector.Probability).ToList();

        public IReadOnlyList<RewardType> GetSpinSectorsTypes() => 
            _sectorsSettings.Select(sector => sector.SpinSectorType).ToList();

        [Serializable]
        public class SectorDataSetting
        {
            [field: SerializeField] public RewardType SpinSectorType;
            [field: SerializeField] public float Value;
            [field: SerializeField] public float Probability;
        }
    }
}