namespace HR_Domin.HR.Interfaces
{
    public interface IManagerBenefits : IBonusEligible, IAppraisable
    {
        void ApproveLeave();
    }
}