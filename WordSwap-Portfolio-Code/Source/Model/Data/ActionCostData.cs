using System;
using System.Collections.Generic;

namespace WordSwap.Model.Data
{
    [Serializable]
    public class ActionCostData
    {
        public int AttackBudget;

        public List<ActionResourceCostData> Resources = new List<ActionResourceCostData>();
    }
}
