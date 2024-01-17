using System.Timers;
using Timer = System.Timers.Timer;

namespace CsuChhs.Blazor.Components.Common
{
    public class AlertMessageService : IDisposable
    {
        public event Action<string, AlertMessageLevels.AlertMessageLevel>? OnShow;
        public event Action? OnHide;
        private Timer? _Countdown;

        public void ShowAlertMessage(string message,
            AlertMessageLevels.AlertMessageLevel level)
        {
            OnShow?.Invoke(message, level);
            StartCountdown();
        }

        public void StartCountdown()
        {
            _SetCoundown();
            if (_Countdown!.Enabled)
            {
                _Countdown.Stop();
                _Countdown.Start();
            }
            else
            {
                _Countdown.Start();
            }
        }

        private void _SetCoundown()
        {
            if (_Countdown != null)
            {
                return;
            }

            _Countdown = new Timer(5000);
            _Countdown.Elapsed += _HideAlertMessage;
            _Countdown.AutoReset = false;
        }

        private void _HideAlertMessage(object? source, ElapsedEventArgs args)
        {
            OnHide?.Invoke();
        }

        public void Dispose()
        {
            _Countdown?.Dispose();
        }
    }
}
