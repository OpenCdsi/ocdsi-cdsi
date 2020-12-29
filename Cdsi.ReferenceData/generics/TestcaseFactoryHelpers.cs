﻿using Cdsi.TestcaseData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Cdsi.ReferenceData
{
    public static class TestcaseFactoryHelpers
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
                CDC_Test_ID = row.Field<string>("CDC_Test_ID"),
                Test_Case_Name = row.Field<string>("Test_Case_Name"),
                Evaluation_Test_Type = row.Field<string>("Evaluation_Test_Type"),
                Forecast_Test_Type = row.Field<string>("Forecast_Test_Type"),
                Vaccine_Group = row.Field<string>("Vaccine_Group"),
                Date_Added = row.Field<DateTime>("Date_Added"),
                Date_Updated = row.Field<DateTime>("Date_Updated"),
                General_Description = row.Field<string>("General_Description"),
                Changed_In_Version = row.Field<string>("Changed_In_Version"),
                Reason_For_Change = row.Field<string>("Reason_For_Change"),
            };
        }

        public static Patient AsPatient(this DataRow row)
        {
            return new Patient()
            {
                DOB = row.Field<DateTime>("DOB"),
                Assessment_Date = row.Field<DateTime>("Assessment_Date"),
                Gender = row.Field<string>("Gender"),
                Med_History_Code = row.Field<string>("Med_History_Code"),
                Med_History_Code_Sys = row.Field<string>("Med_History_Code_Sys"),
                Med_History_Text = row.Field<string>("Med_History_Text")
            };
        }

        public static Forecast AsForecast(this DataRow row)
        {
            return new Forecast()
            {
                Forecast_Num = row.Field<string>("Forecast_#"),
                Earliest_Date = row.Field<DateTime>("Earliest_Date"),
                Past_Due_Date = row.Field<DateTime>("Past_Due_Date"),
                Recommended_Date = row.Field<DateTime>("Recommended_Date")
            };
        }

        public static Evaluation AsEvaluation(this DataRow row)
        {
            return new Evaluation()
            {
                Series_Status = row.Field<string>("Series_Status"),
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
                CVX = row.Field<string>($"CVX_{num}"),
                MVX = row.Field<string>($"MVX_{num}"),
                Date_Administered = row.Field<DateTime>($"Date_Administered_{num}"),
                Evaluation_Reason = row.Field<string>($"Evaluation_Reason_{num}"),
                Evaluation_Status = row.Field<string>($"Evaluation_Status_{num}"),
                Vaccine_Name = row.Field<string>($"Vaccine_Name_{num}")
            };
        }
    }
}