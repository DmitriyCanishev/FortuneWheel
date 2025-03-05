using App.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Spin
{
    public class SpinSectorController : SubviewController<SpinPageController>
    {
        [SerializeField] private Image _iconView = null;

        private void OnValidate()
        {
            _iconView = GetComponentInChildren<Image>();
        }

        public void Setup(SpinDelegator.SectorInfo sectorInfo)
        {
            _iconView.sprite = ParentView.SectorsTypeSettings.GetSectorTypeSettingByInfo(sectorInfo).Sprite;
        }
    }
}