using System;
using System.Linq;
using Spin.Type;
using UnityEngine;

namespace Spin.Configs
{
    [CreateAssetMenu(menuName = "Configs/Spin/SectorsTypeSettings", fileName = "SpinSectorsRewardTypes")]
    public class SectorsTypesSettings : ScriptableObject
    {
        [SerializeField] private SectorTypeSettings[] _sectorsTypeSettings = null;

        [Serializable]
        public class SectorTypeSettings
        {
            [field:SerializeField] public RewardType RewardType { get; private set; }
            [field:SerializeField] public Sprite Sprite { get; private set; }
        }

        public SectorTypeSettings GetSectorTypeSettingByInfo(SpinDelegator.SectorInfo sectorInfo)
        {
            return _sectorsTypeSettings.FirstOrDefault(it => it.RewardType == sectorInfo.SectorType);
        }
    }
}