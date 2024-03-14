using ESAPIX.Constraints;
using System;
using VMS.TPS.Common.Model.API;

namespace ESAPX_StarterUI.ViewModels
{
    public class CTDateConstraint : IConstraint
    {
        public string Name => "CT < 60 days";

        public string FullName => "CT < 60 days";

        public ConstraintResult CanConstrain(PlanningItem pi)
        {
            if (pi.StructureSet?.Image == null) { return new ConstraintResult(this, ResultType.NOT_APPLICABLE, "Plan does not have CT"); }
            return new ConstraintResult(this, ResultType.PASSED, "");
        }

        public ConstraintResult Constrain(PlanningItem pi)
        {
            return ConstrainDate(pi.StructureSet.Image.CreationDateTime);
        }

        public ConstraintResult ConstrainDate(DateTime? ctDate)
        {
            var daysOld = (DateTime.Now - ctDate.Value).TotalDays;
            var msg = $"CT is {daysOld:F2} days old";
            if (daysOld > 60)
            {
                return new ConstraintResult(this, ResultType.ACTION_LEVEL_3, msg);
            }
            else
            {
                return new ConstraintResult(this, ResultType.PASSED, msg);
            }
        }
    }
}