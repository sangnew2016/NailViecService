using System.Data.Entity.Migrations;

namespace Layer.Data.Migrations
{
    /*
        Add-Migration -StartUpProjectName LearningPlatform.Api -ProjectName LearningPlatform.Data.EntityFramework -configuration LearningPlatform.Data.EntityFramework.SurveysDb.SurveysContextConfiguration __NameOfMigrationStep__
        Add-Migration -StartUpProjectName NailViec -ProjectName Layer.Data -configuration Layer.Data.Configuration AddFieldForInitation
        Update-Database -StartUpProjectName LearningPlatform.Api -ProjectName LearningPlatform.Data.EntityFramework -configuration LearningPlatform.Data.EntityFramework.SurveysDb.SurveysContextConfiguration
     */
    internal sealed class Configuration : DbMigrationsConfiguration<NailViecAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NailViecAppContext context)
        {
            //CountryInitData.InitData(context);
            //AddExampleApplicant(context);
            //AddExampleCv(context);
            //AddExampleJob(context);
            //RemoveExampleCalendars(context);
            //RemoveExampleApplications(context);
        }
    }
}
