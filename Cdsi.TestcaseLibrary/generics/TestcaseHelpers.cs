using System;
using System.Collections.Generic;
using System.Data;

namespace Cdsi.TestcaseLibrary
{
    public static class TestcaseHelpers
    {
        public static Testcase AsTestcase(this DataSet data, string id)
        {
            var row = data.Tables[0].Select($"CDC_Test_ID='{id}'")[0];
            var testcase = row.AsTestcase();
            testcase.Patient = row.AsPatient();
            testcase.Forecast = row.AsForecast();
            testcase.Evaluation = row.AsEvaluation();
            testcase.Evaluation.AdministeredDoses = row.AsDoses();
            return testcase;
        }

        public static Testcase AsTestcase(this DataRow row)
        {
            return new Testcase()
            {
                CdcTestId = row.Field<string>("CDC_Test_ID"),
                TestcaseName = row.Field<string>("Test_Case_Name"),
                EvaluationTestType = row.Field<string>("Evaluation_Test_Type"),
                ForecastTestType = row.Field<string>("Forecast_Test_Type"),
                VaccineGroup = row.Field<string>("Vaccine_Group"),
                DateAdded = row.Field<DateTime>("Date_Added"),
                DateUpdated = row.Field<DateTime>("Date_Updated"),
                GeneralDescription = row.Field<string>("General_Description"),
                ChangedInVersion = row.Field<string>("Changed_In_Version"),
                ReasonForChange = row.Field<string>("Reason_For_Change"),
            };
        }

        public static Patient AsPatient(this DataRow row)
        {
            return new Patient()
            {
                DOB = row.Field<DateTime>("DOB"),
                AssessmentDate = row.Field<DateTime>("Assessment_Date"),
                Gender = row.Field<string>("Gender"),
                MedHistoryCode = row.Field<string>("Med_History_Code"),
                MedHistoryCodeSys = row.Field<string>("MedH_istory_Code_Sys"),
                MedHistoryText = row.Field<string>("Med_History_Text")
            };
        }

        public static Forecast AsForecast(this DataRow row)
        {
            return new Forecast()
            {
                ForecastNum = row.Field<string>("Forecast#"),
                EarliestDate = row.Field<DateTime>("Earliest_Date"),
                PastDueDate = row.Field<DateTime>("Past_Due_Date"),
                RecommendedDate = row.Field<DateTime>("Recommended_Date")
            };
        }

        public static Evaluation AsEvaluation(this DataRow row)
        {
            return new Evaluation()
            {
                SeriesStatus = row.Field<string>("Series_Status"),
            };
        }

        public static IEnumerable<Dose> AsDoses(this DataRow row)
        {
            var doses = new List<Dose>();
            for (var i = 1; i <= 7; i++)
            {
                if (string.IsNullOrWhiteSpace(row.Field<string>($"CVX_{i}"))) break;
                doses.Add(row.AsDose(i));
            }
            return doses;
        }

        public static Dose AsDose(this DataRow row, int num)
        {
            return new Dose()
            {
                CVX = row.Field<string>($"CVX{num}"),
                MVX = row.Field<string>($"MVX{num}"),
                DateAdministered = row.Field<DateTime>($"Date_Administered_{num}"),
                EvaluationReason = row.Field<string>($"Evaluation_Reason_{num}"),
                EvaluationStatus = row.Field<string>($"Evaluation_Status_{num}"),
                VaccineName = row.Field<string>($"Vaccine_Name_{num}")
            };
        }
    }
}
