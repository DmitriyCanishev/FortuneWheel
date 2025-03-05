using App.Base;
using Spin.Factory;
using UnityEngine;

namespace Spin.Helper
{
    public class SpinSectorCreator : ViewController
    {
        [SerializeField] private Transform _spinWheelTransform = null;
        [SerializeField] private SpinSectorController _spinSectorController = null;
        [SerializeField, Range(2, 12)] private int _sectorsCount = 6;

        private SectorFactory _sectorFactory = null;

        private const float Round = 360f;

        private void OnValidate()
        {
            _sectorFactory = new SectorFactory(_spinSectorController);
        }

        [ContextMenu(nameof(CreateSectors))]
        private void CreateSectors()
        {
            var rewardSector = Round / _sectorsCount;
            for (int i = 0; i < _sectorsCount; i++)
            {
                _sectorFactory.Create(_spinWheelTransform, rewardSector * i);
            }
        }
    }
}