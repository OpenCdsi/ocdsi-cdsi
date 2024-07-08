using Antigen = Ocdsi.SupportingData.antigenSupportingData;
using Immunity = Ocdsi.SupportingData.antigenSupportingDataImmunity;
using ClinicalHistory = Ocdsi.SupportingData.antigenSupportingDataImmunityClinicalHistory;
using DateOfBirth = Ocdsi.SupportingData.antigenSupportingDataImmunityDateOfBirth;
using Exclusioin = Ocdsi.SupportingData.antigenSupportingDataImmunityDateOfBirthExclusion;
using Contraindications = Ocdsi.SupportingData.antigenSupportingDataContraindications;
using Contraindication = Ocdsi.SupportingData.antigenSupportingDataContraindicationsContraindication;
using Contraindication1 = Ocdsi.SupportingData.antigenSupportingDataContraindicationsContraindication1;
using ContraindicatedVaccine = Ocdsi.SupportingData.antigenSupportingDataContraindicationsContraindicationContraindicatedVaccine;
using Series = Ocdsi.SupportingData.antigenSupportingDataSeries;
using SelectSeries = Ocdsi.SupportingData.antigenSupportingDataSeriesSelectSeries;
using Indication = Ocdsi.SupportingData.antigenSupportingDataSeriesIndication;
using ObservaitonCode = Ocdsi.SupportingData.antigenSupportingDataSeriesIndicationObservationCode;
using Dose = Ocdsi.SupportingData.antigenSupportingDataSeriesSeriesDose;
using Age = Ocdsi.SupportingData.antigenSupportingDataSeriesSeriesDoseAge;
using Interval = Ocdsi.SupportingData.antigenSupportingDataSeriesSeriesDoseInterval;
using IntervalFromRelevantObs = Ocdsi.SupportingData.antigenSupportingDataSeriesSeriesDoseIntervalFromRelevantObs;
using AllowableInterval = Ocdsi.SupportingData.antigenSupportingDataSeriesSeriesDoseAllowableInterval;
using PreferableVaccine = Ocdsi.SupportingData.antigenSupportingDataSeriesSeriesDosePreferableVaccine;
using AllowableVaccine = Ocdsi.SupportingData.antigenSupportingDataSeriesSeriesDoseAllowableVaccine;
using InadvertentVaccine = Ocdsi.SupportingData.antigenSupportingDataSeriesSeriesDoseInadvertentVaccine;
using ConditionalSkip = Ocdsi.SupportingData.antigenSupportingDataSeriesSeriesDoseConditionalSkip;
using Set = Ocdsi.SupportingData.antigenSupportingDataSeriesSeriesDoseConditionalSkipSet;
using Condition = Ocdsi.SupportingData.antigenSupportingDataSeriesSeriesDoseConditionalSkipSetCondition;
using SeasonalRecommendation = Ocdsi.SupportingData.antigenSupportingDataSeriesSeriesDoseSeasonalRecommendation;
using Schedule = Ocdsi.SupportingData.scheduleSupportingData;
using LiveVirusConflict = Ocdsi.SupportingData.scheduleSupportingDataLiveVirusConflict;
using Previous = Ocdsi.SupportingData.scheduleSupportingDataLiveVirusConflictPrevious;
using Current = Ocdsi.SupportingData.scheduleSupportingDataLiveVirusConflictCurrent;
using VaccineGroup = Ocdsi.SupportingData.scheduleSupportingDataVaccineGroup;
using GroupMap = Ocdsi.SupportingData.scheduleSupportingDataVaccineGroupMap;
using CvxMap = Ocdsi.SupportingData.scheduleSupportingDataCvxMap;
using Association = Ocdsi.SupportingData.scheduleSupportingDataCvxMapAssociation;
using Observation = Ocdsi.SupportingData.scheduleSupportingDataObservation;
using CodedValue = Ocdsi.SupportingData.scheduleSupportingDataObservationCodedValuesCodedValue;
using Ocdsi.SupportingData;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Ocdsi.UnitTests.SupportingData
{
    [TestClass]
    public class ClassAliasTests
    {
        [TestMethod]
        public void AntigenAliasTest()
        {
            var repo = new Repository(TestData.ResourcePath);
            var result = repo.Antigen("HepB");

            Assert.IsInstanceOfType<Antigen>(result);
        }
    }
}
