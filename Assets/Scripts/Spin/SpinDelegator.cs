using System;
using System.Collections.Generic;
using System.Linq;
using Spin.Configs;
using Spin.Type;
using UnityEngine;
using Utils;

namespace Spin
{
    public class SpinDelegator
    {
        public bool CanPlay = true;

        public readonly IReadOnlyList<SectorInfo> Sectors = null;
        public SectorInfo? LastRewardedSector { get; private set; }

        private readonly IReadOnlyList<float> _sectorValues = null;
        private readonly IReadOnlyList<RewardType> _spinnerSectorTypes = null;
        private readonly IReadOnlyList<float> _sectorsProbabilities = null;

        public SpinDelegator(SectorsDataSettings sectorsDataSettings)
        {
            _sectorValues = sectorsDataSettings.GetSectorsValues();
            _spinnerSectorTypes = sectorsDataSettings.GetSpinSectorsTypes();
            _sectorsProbabilities = sectorsDataSettings.GetSectorsProbability();

            var sectors = new List<SectorInfo>(_spinnerSectorTypes.Count);
            sectors.AddRange(
                _spinnerSectorTypes.Select(
                    (t, i) => new SectorInfo(i, t, _sectorValues[i], _sectorsProbabilities[i])
                )
            );
            Sectors = sectors;
        }

        public void PlaySpin()
        {
            if (!CanPlay)
            {
                throw new Exception("Spin not ready for game yet!");
            }

            LastRewardedSector = Sectors.WeightedRandom(it => it.Probability);
        }

        public void ApplyReward()
        {
            var sectorInfo = LastRewardedSector!.Value;
            Debug.LogError($"Reward {sectorInfo.SectorType} added");
            LastRewardedSector = null;
        }

        public readonly struct SectorInfo
        {
            public readonly int Index;
            public readonly RewardType SectorType;
            public readonly float Value;
            public readonly float Probability;

            public SectorInfo(int index, RewardType sectorType, float value, float probability)
            {
                Index = index;
                SectorType = sectorType;
                Value = value;
                Probability = probability;
            }

            public override string ToString()
            {
                return
                    $"{nameof(Index)} : {Index}, " +
                    $"{nameof(SectorType)} : {SectorType}, " +
                    $"{nameof(Value)} : {Value}, " +
                    $"{nameof(Probability)} : {Probability}";
            }
        }
    }
}