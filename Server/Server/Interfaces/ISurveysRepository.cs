using Server.Models;

namespace Server.Interfaces
{
    public interface ISurveysRepository
    {
        int? SubmitSurvey(SurveysPost newSurvey);
        int GetCount();
    }
}
