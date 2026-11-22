using System;
using WordSwap.Model.Data;
using WordSwap.Model.Enums;
using WordSwap.Model.Runtime;

namespace WordSwap.Core
{
    public class ActionCostService
    {
        public bool CanPay(
            ActionCostData cost, RuntimePlayer player, RuntimePlayerTurn turn)
        {
            ValidateState(player, turn);

            var totals = CalculateTotals(cost);
            return HasEnoughResources(cost, totals, player, turn);
        }

        public bool TryPay(
            ActionCostData cost, RuntimePlayer player, RuntimePlayerTurn turn)
        {
            ValidateState(player, turn);

            var totals = CalculateTotals(cost);

            // 하나라도 부족하면 아무 자원도 변경하지 않는다.
            if (!HasEnoughResources(cost, totals, player, turn))
            {
                return false;
            }

            if (!turn.TrySpendAttackBudget(cost.AttackBudget))
            {
                return false;
            }

            player.CurrentHP -= totals.HP;
            player.CurrentMP -= totals.MP;
            player.Gold -= totals.Gold;

            return true;
        }

        private static bool HasEnoughResources(
            ActionCostData cost,(int HP, int MP, int Gold) totals, 
            RuntimePlayer player, RuntimePlayerTurn turn)
        {
            return player.CurrentHP > totals.HP
                && player.CurrentMP >= totals.MP
                && player.Gold >= totals.Gold
                && turn.CanSpendAttackBudget(cost.AttackBudget);
        }

        private static (int HP, int MP, int Gold) CalculateTotals(ActionCostData cost)
        {
            if (cost == null)
            {
                throw new ArgumentNullException(nameof(cost));
            }

            if (cost.AttackBudget < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cost.AttackBudget));
            }

            if (cost.Resources == null)
            {
                throw new ArgumentException(
                    "추가 비용이 없으면 Resources를 빈 목록으로 지정하세요.", nameof(cost));
            }

            int hp = 0;
            int mp = 0;
            int gold = 0;

            foreach (ActionResourceCostData resource in cost.Resources)
            {
                if (resource == null || resource.Amount <= 0)
                {
                    throw new ArgumentException(
                        "자원 비용 항목은 존재해야 하고 Amount는 양수여야 합니다.", nameof(cost));
                }

                checked
                {
                    switch (resource.Resource)
                    {
                        case ActionResourceType.HP:
                            hp += resource.Amount;
                            break;

                        case ActionResourceType.MP:
                            mp += resource.Amount;
                            break;

                        case ActionResourceType.Gold:
                            gold += resource.Amount;
                            break;

                        default:
                            throw new ArgumentException(
                                "지원하지 않는 비용 자원입니다.", nameof(cost));
                    }
                }
            }

            return (hp, mp, gold);
        }

        private static void ValidateState(RuntimePlayer player, RuntimePlayerTurn turn)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            if (turn == null)
            {
                throw new ArgumentNullException(nameof(turn));
            }
        }
    }
}
