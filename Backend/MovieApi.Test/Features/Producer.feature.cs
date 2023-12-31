﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace MovieApi.Test.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ProducerResourceFeature : object, Xunit.IClassFixture<ProducerResourceFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Producer.feature"
#line hidden
        
        public ProducerResourceFeature(ProducerResourceFeature.FixtureData fixtureData, MovieApi_Test_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Producer Resource", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="GetAll Producers")]
        [Xunit.TraitAttribute("FeatureTitle", "Producer Resource")]
        [Xunit.TraitAttribute("Description", "GetAll Producers")]
        [Xunit.TraitAttribute("Category", "GetAllProducers")]
        [Xunit.InlineDataAttribute("producers", "200", "[{\"id\":1,\"name\":\"Shobu\",\"bio\":\"Good Producer\",\"dob\":\"12-12-1998 00:00:00\",\"gender" +
            "\":\"Male\"},{\"id\":2,\"name\":\"Viswak\",\"bio\":\"Star Producer\",\"dob\":\"12-12-1998 00:00:" +
            "00\",\"gender\":\"Male\"}]", new string[0])]
        public void GetAllProducers(string uRL, string responseCode, string responseData, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GetAllProducers"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("URL", uRL);
            argumentsOfScenario.Add("ResponseCode", responseCode);
            argumentsOfScenario.Add("ResponseData", responseData);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("GetAll Producers", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
 testRunner.Given("I am a client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 6
 testRunner.When(string.Format("I make GET Request \'{0}\'", uRL), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 7
 testRunner.Then(string.Format("response code must be \'{0}\'", responseCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 8
 testRunner.And(string.Format("response data must look like \'{0}\'", responseData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Get Producer by ID")]
        [Xunit.TraitAttribute("FeatureTitle", "Producer Resource")]
        [Xunit.TraitAttribute("Description", "Get Producer by ID")]
        [Xunit.TraitAttribute("Category", "GetProducerById")]
        [Xunit.InlineDataAttribute("producers/1", "200", "{\"id\":1,\"name\":\"Shobu\",\"bio\":\"Good Producer\",\"dob\":\"12-12-1998 00:00:00\",\"gender\"" +
            ":\"Male\"}", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("producers/2", "200", "{\"id\":2,\"name\":\"Viswak\",\"bio\":\"Star Producer\",\"dob\":\"12-12-1998 00:00:00\",\"gender" +
            "\":\"Male\"}", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("producers/20", "404", "Producer with Id 20 not found", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("producers/6", "404", "Producer with Id 6 not found", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("producers/-1", "404", "Invalid ProducerId", new string[] {
                "InvalidCase"})]
        public void GetProducerByID(string uRL, string responseCode, string responseData, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GetProducerById"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("URL", uRL);
            argumentsOfScenario.Add("ResponseCode", responseCode);
            argumentsOfScenario.Add("ResponseData", responseData);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Producer by ID", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 14
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 15
 testRunner.Given("I am a client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 16
    testRunner.When(string.Format("I make GET Request \'{0}\'", uRL), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 17
 testRunner.Then(string.Format("response code must be \'{0}\'", responseCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 18
 testRunner.And(string.Format("response data must look like \'{0}\'", responseData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Create Producer")]
        [Xunit.TraitAttribute("FeatureTitle", "Producer Resource")]
        [Xunit.TraitAttribute("Description", "Create Producer")]
        [Xunit.TraitAttribute("Category", "CreateProducer")]
        [Xunit.InlineDataAttribute("producers", "{\"name\":\"Danayya\",\"bio\":\"Great Producer\",\"dob\":\"12/06/1992\",\"gender\":\"Male\"}", "201", "Producer successfully created", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("producers", "{\"name\":\"\",\"bio\":\"Fantstic producer\",\"dob\":\"14/08/1976\",\"gender\":\"Female\"}", "400", "Producer name can not be empty", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("producers", "{\"name\":\"Kamal\",\"bio\":\"\",\"dob\":\"19/08/1979\",\"gender\":\"Male\"}", "400", "Bio can not be empty", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("producers", "{\"name\":\"Kamal\",\"bio\":\"TollyWood producer\",\"dob\":\"date\",\"gender\":\"Male\"}", "400", "Provide valid Dob", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("producers", "{\"name\":\"Kamal\",\"bio\":\"TollyWood producer\",\"dob\":\"19/08/1979\",\"gender\":\"\"}", "400", "Gender can not be empty", new string[] {
                "InvalidCase"})]
        public void CreateProducer(string uRL, string requestData, string responseCode, string responseData, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CreateProducer"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("URL", uRL);
            argumentsOfScenario.Add("RequestData", requestData);
            argumentsOfScenario.Add("ResponseCode", responseCode);
            argumentsOfScenario.Add("ResponseData", responseData);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Producer", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 34
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 35
 testRunner.Given("I am a client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 36
 testRunner.When(string.Format("I am make POST Request \'{0}\' with the following data \'{1}\'", uRL, requestData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 37
 testRunner.Then(string.Format("response code must be \'{0}\'", responseCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 38
 testRunner.And(string.Format("response data must look like \'{0}\'", responseData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Update Producer")]
        [Xunit.TraitAttribute("FeatureTitle", "Producer Resource")]
        [Xunit.TraitAttribute("Description", "Update Producer")]
        [Xunit.TraitAttribute("Category", "UpdateProducer")]
        [Xunit.InlineDataAttribute("producers/1", "{\"name\":\"Arjun\",\"bio\":\"Bollywood Producer\",\"dob\":\"19/08/1979\",\"gender\":\"Male\"}", "200", "Producer updated successfully", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("producers/20", "{\"name\":\"Tharun\",\"bio\":\"Nice Producer\",\"dob\":\"19/08/1979\",\"gender\":\"Male\"}", "400", "Producer with Id 20 not found", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("producers/-1", "{\"name\":\"Tharun\",\"bio\":\"Nice Producer\",\"dob\":\"19/08/1979\",\"gender\":\"Male\"}", "400", "Invalid ProducerId", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("producers/1", "{\"name\":\"\",\"bio\":\"Nice Producer\",\"dob\":\"19/08/1979\",\"gender\":\"Male\"}", "400", "Producer name can not be empty", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("producers/1", "{\"name\":\"Nikhil\",\"bio\":\"\",\"dob\":\"19/08/1979\",\"gender\":\"Male\"}", "400", "Bio can not be empty", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("producers/1", "{\"name\":\"Nikhil\",\"bio\":\"Nice Producer\",\"dob\":\"hhh\",\"gender\":\"Male\"}", "400", "Provide valid Dob", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("producers/1", "{\"name\":\"Nikhil\",\"bio\":\"Nice Producer\",\"dob\":\"19/08/1979\",\"gender\":\"\"}", "400", "Gender can not be empty", new string[] {
                "InvalidCase"})]
        public void UpdateProducer(string uRL, string requestData, string responseCode, string responseData, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "UpdateProducer"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("URL", uRL);
            argumentsOfScenario.Add("RequestData", requestData);
            argumentsOfScenario.Add("ResponseCode", responseCode);
            argumentsOfScenario.Add("ResponseData", responseData);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update Producer", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 54
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 55
 testRunner.Given("I am a client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 56
 testRunner.When(string.Format("I make PUT Request \'{0}\' with the following Data \'{1}\'", uRL, requestData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 57
 testRunner.Then(string.Format("response code must be \'{0}\'", responseCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 58
 testRunner.And(string.Format("response data must look like \'{0}\'", responseData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Delete Producer")]
        [Xunit.TraitAttribute("FeatureTitle", "Producer Resource")]
        [Xunit.TraitAttribute("Description", "Delete Producer")]
        [Xunit.TraitAttribute("Category", "DeleteProducer")]
        [Xunit.InlineDataAttribute("producers/1", "200", "Producer Deleted Succcessfully", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("producers/2", "200", "Producer Deleted Succcessfully", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("producers/-1", "400", "Invalid ProducerId", new string[] {
                "InValidCase"})]
        [Xunit.InlineDataAttribute("producers/13", "400", "Producer with Id 13 does not found", new string[] {
                "InValidCase"})]
        public void DeleteProducer(string uRL, string responseCode, string responseData, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DeleteProducer"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("URL", uRL);
            argumentsOfScenario.Add("ResponseCode", responseCode);
            argumentsOfScenario.Add("ResponseData", responseData);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete Producer", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 76
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 77
 testRunner.Given("I am a client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 78
 testRunner.When(string.Format("I make DELETE Request \'{0}\'", uRL), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 79
 testRunner.Then(string.Format("response code must be \'{0}\'", responseCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 80
 testRunner.And(string.Format("response data must look like \'{0}\'", responseData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                ProducerResourceFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ProducerResourceFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
