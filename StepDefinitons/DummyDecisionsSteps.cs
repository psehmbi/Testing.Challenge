using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Testing.Challenge.Extensions;
using Testing.Challenge.Models;
using Xunit;

namespace Testing.Challenge.StepDefinitons
{
    [Binding]
    public class DummyDecisionsSteps
    {
        private Applicant _applicant;
        private HttpResponseMessage _result;
        

        [Given(@"an applicant with the following data")]
        public void GivenAnApplicantWithTheFollowingData(Table table)
        {
            var applicantData = table.CreateInstance<Applicant>();
            _applicant = new Applicant
            {
                DateOfBirth = applicantData.DateOfBirth == string.Empty ? null: applicantData.DateOfBirth,
                FirstName = applicantData.FirstName == string.Empty ? null : applicantData.FirstName,
                LastName = applicantData.LastName == string.Empty ? null : applicantData.LastName
            };
        }
        
        [When(@"the appication is submitted")]
        public async Task WhenTheAppicationIsSubmitted()
        {
            _result = await _applicant.Submit();
        }
        
        [Then(@"the response is (.*)")]
        public void ThenTheResponseIs(string expectedHttpStatusCode)
        {
            Assert.Equal(expectedHttpStatusCode, _result.StatusCode.ToString());
        }

        [Then(@"the decision is (.*)")]
        public async Task ThenTheDecisionIs(string expectedDecision)
        {
            var response = JsonConvert.DeserializeObject<dynamic>(await _result.Content.ReadAsStringAsync());
            string descision = response.decisionResult;
            Assert.Equal(expectedDecision, descision);
        }
    }
}
