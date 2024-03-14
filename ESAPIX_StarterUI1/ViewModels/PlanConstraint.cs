using ESAPIX.Constraints;
using Prism.Mvvm;

namespace ESAPX_StarterUI.ViewModels
{
    //Represents a constraint + Result for user interface
    public class PlanConstraint : BindableBase
    {
        public PlanConstraint(IConstraint con)
        {
            this.Constraint = con;
        }

        private IConstraint _constraint;
        public IConstraint Constraint
        {
            get { return _constraint; }
            set { SetProperty(ref _constraint, value); }
        }

        private ConstraintResult _result;
        public ConstraintResult Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }
    }
}