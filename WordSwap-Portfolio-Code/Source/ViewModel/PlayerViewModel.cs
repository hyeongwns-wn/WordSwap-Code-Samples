using WordSwap.Core;
using WordSwap.Model.Runtime;

namespace WordSwap.ViewModel
{
    public class PlayerViewModel : ViewModelBase
    {
        public Observable<int> CurrentHP { get; private set; }
        public Observable<int> MaxHP { get; private set; }
        public Observable<int> CurrentMP { get; private set; }
        public Observable<int> MaxMP { get; private set; }
        public Observable<int> Gold { get; private set; }

        public Observable<int> STR { get; private set; }
        public Observable<int> DEX { get; private set; }
        public Observable<int> INT { get; private set; }
        public Observable<int> CHA { get; private set; }

        public PlayerViewModel()
        {
            CurrentHP = CreateObservable<int>(0);
            MaxHP = CreateObservable<int>(0);
            CurrentMP = CreateObservable<int>(0);
            MaxMP = CreateObservable<int>(0);
            Gold = CreateObservable<int>(0);
            STR = CreateObservable<int>(0);
            DEX = CreateObservable<int>(0);
            INT = CreateObservable<int>(0);
            CHA = CreateObservable<int>(0);
        }

        public void Initialize(RuntimePlayer playerData)
        {
            CurrentHP.Value = playerData.CurrentHP;
            MaxHP.Value = playerData.MaxHP;
            CurrentMP.Value = playerData.CurrentMP;
            MaxMP.Value = playerData.MaxMP;
            Gold.Value = playerData.Gold;

            STR.Value = playerData.BaseSTR;
            DEX.Value = playerData.BaseDEX;
            INT.Value = playerData.BaseINT;
            CHA.Value = playerData.BaseCHA;
        }
    }
}
