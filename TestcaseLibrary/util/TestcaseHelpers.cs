using System;
using System.Collections.Generic;
using System.Data;

namespace Cdsi.TestcaseLibrary
{
    public static class TestcaseHelpers
    {
        public static testcase AsTestcase(this DataRow row)
        {
            return new testcase()
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
                Evaluation = row.AsEvaluation(),
                Forecast = row.AsForecast(),
                Patient = row.AsPatient()
            };
        }

        public static testcasePatient AsPatient(this DataRow row)
        {
            return new testcasePatient()
            {
                DOB = row.Field<DateTime>("DOB"),
                AssessmentDate = row.Field<DateTime>("Assessment_Date"),
                Gender = row.Field<string>("Gender"),
                MedHistoryCode = row.Field<string>("Med_History_Code"),
                MedHistoryCodeSys = row.Field<string>("Med_History_Code_Sys"),
                MedHistoryText = row.Field<string>("Med_History_Text")
            };
        }

        public static testcaseForecastExpectedResult AsForecast(this DataRow row)
        {
            return new testcaseForecastExpectedResult()
            {
                ForecastNum = row.Field<string>("Forecast_#"),
                PastDueDate = row.AsDateTime("Past_Due_Date"),
                EarliestDate = row.AsDateTime("Earliest_Date"),
                RecommendedDate = row.AsDateTime("Recommended_Date")
            };
        }

        public static testcaseEvaluationExpectedResult AsEvaluation(this DataRow row)
        {
            return new testcaseEvaluationExpectedResult()
            {
                SeriesStatus = row.Field<string>("Series_Status"),
                AdministeredDoses = row.AsDoses()
            };
        }

        public static IEnumerable<testcaseVaccineDoseAdministered> AsDoses(this DataRow row)
        {
            var doses = new List<testcaseVaccineDoseAdministered>();
            for (var i = 1; i <= 7; i++)
            {
                if (string.IsNullOrWhiteSpace(row.Field<string>($"CVX_{i}"))) break;
                doses.Add(row.AsDose(i));
            }
            return doses;
        }

        public static testcaseVaccineDoseAdministered AsDose(this DataRow row, int num)
        {
            return new testcaseVaccineDoseAdministered()
            {
                CVX = row.Field<string>($"CVX_{num}"),
                MVX = row.Field<string>($"MVX_{num}"),
                DateAdministered = row.Field<DateTime>($"Date_Administered_{num}"),
                EvaluationReason = row.Field<string>($"Evaluation_Reason_{num}"),
                EvaluationStatus = row.Field<string>($"Evaluation_Status_{num}"),
                VaccineName = row.Field<string>($"Vaccine_Name_{num}")
            };
        }

        public static DateTime AsDateTime(this DataRow row, string field)
        {
            try
            {
                return row.Field<DateTime>(field);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public static IEnumerable<DataRow> AsEnumerable(this DataRowCollection rows)
        {
            foreach(DataRow row in rows)
            {
                yield return row;
            }
        }
    }
}
