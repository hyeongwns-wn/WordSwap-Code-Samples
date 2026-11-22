using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WordSwap.Core;

namespace WordSwap.View
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private Image _fill;
        [SerializeField] private TMP_Text _hpText;

        private Observable<(int Current, int Maximum)> _health;

        public void Bind(Observable<(int Current, int Maximum)> health)
        {
            if (health == null)
            {
                throw new ArgumentNullException(nameof(health));
            }

            if (_fill == null || _hpText == null)
            {
                throw new InvalidOperationException(
                    "HealthBar의 Fill과 HpText를 연결해 주세요.");
            }

            Unbind();

            _health = health;
            _health.OnChanged += Refresh;

            Refresh(_health.Value);
        }

        private void Refresh((int Current, int Maximum) health)
        {
            _hpText.text = $"{health.Current}/{health.Maximum}";

            _fill.fillAmount = health.Maximum > 0
                ? Mathf.Clamp01((float)health.Current / health.Maximum) : 0f;
        }

        private void Unbind()
        {
            if (_health == null)
            {
                return;
            }

            _health.OnChanged -= Refresh;
            _health = null;
        }

        private void OnDestroy()
        {
            Unbind();
        }
    }
}
