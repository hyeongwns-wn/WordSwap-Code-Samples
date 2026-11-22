using System;
using WordSwap.Model.Enums;

namespace WordSwap.Model.Data
{
    [Serializable]
    public class ActionResourceCostData
    {
        public ActionResourceType Resource;
        public int Amount;
    }
}
