using UnityEngine;

namespace Spin.Factory
{
    public class SectorFactory
    {
        private readonly SpinSectorController _spinSector = null;

        public SectorFactory(SpinSectorController spinSector)
        {
            _spinSector = spinSector;
        }

        public void Create(Transform parent, float angle)
        {
            var parentPosition = parent.position;
            var newSector = Object.Instantiate(_spinSector, parentPosition, Quaternion.identity, parent).transform;
            newSector.RotateAround(parentPosition, Vector3.back, angle);
        }
    }
}