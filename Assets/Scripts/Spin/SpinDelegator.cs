using System;
using System.Collections.Generic;
using System.Linq;
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

        public SpinDelegator()
        {
            _sectorValues = new[] {5f, 2f, 1f, 10f, 3f, 4f, 0.3f, 0.5f};
            _spinnerSectorTypes = new[]
                {RewardType.Coins, RewardType.Bolt, RewardType.Lock, RewardType.Heart, RewardType.Star, RewardType.Coins, RewardType.Bolt, RewardType.Heart};
            _sectorsProbabilities = new[] {0.5f, 0.3f, 0.4f, 0.2f, 0.25f, 0.5f, 0.4f, 0.3f};

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