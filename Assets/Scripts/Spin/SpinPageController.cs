using System;
using System.Collections;
using App.Base;
using DG.Tweening;
using Spin.Configs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Spin
{
    public class SpinPageController : ViewController
    {
        [SerializeField] private Transform _spin = null;

        [SerializeField] private SpinSectorController[] _sectors = null;
        [SerializeField] private SectorsDataSettings _sectorsDataSettings = null;

        [SerializeField] private bool _isSectorsClockwiseDirection = true;

        [field: SerializeField] public SectorsTypesSettings SectorsTypeSettings { get; private set; }

        private SpinDelegator _spinDelegator = null;
        private EventSystem _eventSystem = null;

        protected override void Awake()
        {
            base.Awake();
            _spinDelegator = new SpinDelegator(_sectorsDataSettings);
            _eventSystem = EventSystem.current;
        }

        protected override void Bind()
        {
            base.Bind();

            for (int i = 0; i < _spinDelegator.Sectors.Count; i++)
            {
                Debug.LogError($"sector[{i}] = {_spinDelegator.Sectors[i]}]");
                _sectors[i].Setup(_spinDelegator.Sectors[i]);
            }
        }

        public void Spin()
        {
            if (_spinDelegator.CanPlay)
            {
                _eventSystem.enabled = false;
                _spinDelegator.PlaySpin();
                LaunchSpin(_spinDelegator.LastRewardedSector!.Value, OnRotationFinished);
            }
        }

        private void LaunchSpin(SpinDelegator.SectorInfo sectorInfo,
            Func<SpinDelegator.SectorInfo, IEnumerator> onRotationFinished)
        {
            Debug.LogError($"Reward = {sectorInfo.Index}");
            const float round = 360f;
            float rotateCount = round * 10f;
            float sector = round / _sectors.Length;
            float targetAngle = rotateCount + sector * sectorInfo.Index;
            Vector3 targetPosition = new Vector3(0, 0, _isSectorsClockwiseDirection ? targetAngle : -targetAngle);

            _spin
                .DORotate(targetPosition, 5f, RotateMode.FastBeyond360)
                .OnComplete(() => StartCoroutine(onRotationFinished.Invoke(sectorInfo)));
        }

        private IEnumerator OnRotationFinished(SpinDelegator.SectorInfo sectorInfo)
        {
            yield return new WaitForSeconds(0.1f);
            Debug.LogError($"Your Reward is {sectorInfo.SectorType}");
            _eventSystem.enabled = true;
        }
    }
}