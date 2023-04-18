using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreTask.WindowsApp
{
    public class CalculateWorker
    {
        private List<Condition> conditions = new List<Condition>
        {
            new Condition{ MinValue = int.MinValue, MaxValue = 5, ResultValue = 50, ConditionRule = ConditionRule.Normal }, //[-∞, ...., 5]
            new Condition{ MinValue = 5,  MaxValue= 6, ResultValue = 60, ConditionRule = ConditionRule.EqualToMinAndMax }, //[5,6]
            new Condition{ MinValue = 10, MaxValue= 14, ResultValue = 70, ConditionRule = ConditionRule.EqualToMax }, //[11,12,13,14]
            new Condition{ MinValue = 14, MaxValue= 20, ResultValue = 90, ConditionRule = ConditionRule.Normal }, //[15,16,17,18,19]
            new Condition{ MinValue = 20, MaxValue= int.MaxValue, ResultValue = 100, ConditionRule = ConditionRule.EqualToMin } //[20, ..., ∞]
        };

        private Condition CalculateCondition(Condition condition, int input)
        {
            switch (condition.ConditionRule)
            {
                case ConditionRule.Normal:
                    if (condition.MinValue < input && condition.MaxValue > input)
                        return condition;
                    break;
                case ConditionRule.EqualToMinAndMax:
                    if (condition.MinValue <= input && condition.MaxValue >= input)
                        return condition;
                    break;
                case ConditionRule.EqualToMin:
                    if (condition.MinValue <= input && condition.MaxValue > input)
                        return condition;
                    break;
                case ConditionRule.EqualToMax:
                    if (condition.MinValue < input && condition.MaxValue >= input)
                        return condition;
                    break;
                default:
                    if (condition.MinValue < input && condition.MaxValue > input)
                        return condition;
                    break;
            }
            return null;
        }

        public Condition? GetConditionResultByInput(int input)
        {
            Condition calculatedCondition = new Condition();
            foreach (var condition in conditions)
            {
                var conditionCheck = CalculateCondition(condition, input);
                if (conditionCheck != null)
                {
                    calculatedCondition = conditionCheck;
                    break;
                }
            }
            return calculatedCondition;
        }
    }
    public class Condition
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int ResultValue { get; set; }
        public ConditionRule ConditionRule { get; set; }
    }

    public enum ConditionRule
    {
        Normal = 0, //BiggerMin and LesserMax
        EqualToMinAndMax = 1,
        EqualToMin = 2,
        EqualToMax = 3
    }

}
