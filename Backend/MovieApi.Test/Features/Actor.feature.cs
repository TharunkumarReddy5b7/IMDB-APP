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
    public partial class ActorResourceFeature : object, Xunit.IClassFixture<ActorResourceFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Actor.feature"
#line hidden
        
        public ActorResourceFeature(ActorResourceFeature.FixtureData fixtureData, MovieApi_Test_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Actor Resource", null, ProgrammingLanguage.CSharp, featureTags);
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
        
        [Xunit.SkippableTheoryAttribute(DisplayName="GetAll Actors")]
        [Xunit.TraitAttribute("FeatureTitle", "Actor Resource")]
        [Xunit.TraitAttribute("Description", "GetAll Actors")]
        [Xunit.TraitAttribute("Category", "GetAllActors")]
        [Xunit.InlineDataAttribute("actors", "200", "[{\"id\":1,\"name\":\"Prabhas\",\"bio\":\"Good Actor\",\"dob\":\"12-12-1998 00:00:00\",\"gender\"" +
            ":\"Male\"},{\"id\":2,\"name\":\"Rana\",\"bio\":\"PowerStar\",\"dob\":\"12-12-1998 00:00:00\",\"ge" +
            "nder\":\"Male\"}]", new string[0])]
        public void GetAllActors(string uRL, string responseCode, string responseData, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GetAllActors"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("URL", uRL);
            argumentsOfScenario.Add("ResponseCode", responseCode);
            argumentsOfScenario.Add("ResponseData", responseData);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("GetAll Actors", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Get Actor by ID")]
        [Xunit.TraitAttribute("FeatureTitle", "Actor Resource")]
        [Xunit.TraitAttribute("Description", "Get Actor by ID")]
        [Xunit.TraitAttribute("Category", "GetActorById")]
        [Xunit.InlineDataAttribute("actors/1", "200", "{\"id\":1,\"name\":\"Prabhas\",\"bio\":\"Good Actor\",\"dob\":\"12-12-1998 00:00:00\",\"gender\":" +
            "\"Male\"}", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("actors/2", "200", "{\"id\":2,\"name\":\"Rana\",\"bio\":\"PowerStar\",\"dob\":\"12-12-1998 00:00:00\",\"gender\":\"Mal" +
            "e\"}", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("actors/20", "404", "Actor with ID 20 not found", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("actors/6", "404", "Actor with ID 6 not found", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("actors/-1", "404", "Invalid ActorId", new string[] {
                "InvalidCase"})]
        public void GetActorByID(string uRL, string responseCode, string responseData, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GetActorById"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("URL", uRL);
            argumentsOfScenario.Add("ResponseCode", responseCode);
            argumentsOfScenario.Add("ResponseData", responseData);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Actor by ID", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Create Actor")]
        [Xunit.TraitAttribute("FeatureTitle", "Actor Resource")]
        [Xunit.TraitAttribute("Description", "Create Actor")]
        [Xunit.TraitAttribute("Category", "CreateActor")]
        [Xunit.InlineDataAttribute("actors", "{\"name\":\"Ntr\",\"bio\":\"great actor\",\"dob\":\"12/06/1992\",\"gender\":\"Male\"}", "201", "Actor successfully created", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("actors", "{\"name\":\"\",\"bio\":\"Fantstic actor\",\"dob\":\"14/08/1976\",\"gender\":\"Female\"}", "400", "Actor name can not be empty", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("actors", "{\"name\":\"Prabhas\",\"bio\":\"\",\"dob\":\"19/08/1979\",\"gender\":\"Male\"}", "400", "Bio can not be empty", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("actors", "{\"name\":\"Prabhas\",\"bio\":\"TollyWood Actor\",\"dob\":\"date\",\"gender\":\"Male\"}", "400", "Provide valid Dob", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("actors", "{\"name\":\"Prabhas\",\"bio\":\"TollyWood Actor\",\"dob\":\"19/08/1979\",\"gender\":\"\"}", "400", "Gender can not be empty", new string[] {
                "InvalidCase"})]
        public void CreateActor(string uRL, string requestData, string responseCode, string responseData, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CreateActor"};
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
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Actor", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Update Actor")]
        [Xunit.TraitAttribute("FeatureTitle", "Actor Resource")]
        [Xunit.TraitAttribute("Description", "Update Actor")]
        [Xunit.TraitAttribute("Category", "UpdateActor")]
        [Xunit.InlineDataAttribute("actors/1", "{\"name\":\"NTR\",\"bio\":\"Bulk Actor\",\"dob\":\"19/08/1979\",\"gender\":\"Male\"}", "200", "Actor Updated Successfully", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("actors/20", "{\"name\":\"Tharun\",\"bio\":\"Bulk Actor\",\"dob\":\"19/08/1979\",\"gender\":\"Male\"}", "400", "Actor with Id 20 not found", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("actors/-1", "{\"name\":\"Tharun\",\"bio\":\"Bulk Actor\",\"dob\":\"19/08/1979\",\"gender\":\"Male\"}", "400", "Invalid ActorId", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("actors/1", "{\"name\":\"\",\"bio\":\"Bulk Actor\",\"dob\":\"19/08/1979\",\"gender\":\"Male\"}", "400", "Actor name can not be empty", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("actors/1", "{\"name\":\"Nikhil\",\"bio\":\"\",\"dob\":\"19/08/1979\",\"gender\":\"Male\"}", "400", "Bio can not be empty", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("actors/1", "{\"name\":\"Nikhil\",\"bio\":\"Bulk Actor\",\"dob\":\"hhh\",\"gender\":\"Male\"}", "400", "Provide valid Dob", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("actors/1", "{\"name\":\"Nikhil\",\"bio\":\"Bulk Actor\",\"dob\":\"19/08/1979\",\"gender\":\"\"}", "400", "Gender can not be empty", new string[] {
                "InvalidCase"})]
        public void UpdateActor(string uRL, string requestData, string responseCode, string responseData, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "UpdateActor"};
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
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update Actor", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 55
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 56
 testRunner.Given("I am a client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 57
 testRunner.When(string.Format("I make PUT Request \'{0}\' with the following Data \'{1}\'", uRL, requestData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 58
 testRunner.Then(string.Format("response code must be \'{0}\'", responseCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 59
 testRunner.And(string.Format("response data must look like \'{0}\'", responseData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Delete Actor")]
        [Xunit.TraitAttribute("FeatureTitle", "Actor Resource")]
        [Xunit.TraitAttribute("Description", "Delete Actor")]
        [Xunit.TraitAttribute("Category", "DeleteActor")]
        [Xunit.InlineDataAttribute("actors/1", "200", "Actor Deleted Succcessfully", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("actors/2", "200", "Actor Deleted Succcessfully", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("actors/-1", "400", "Invalid ActorId", new string[] {
                "InValidCase"})]
        [Xunit.InlineDataAttribute("actors/13", "400", "Actor with Id 13 does not found", new string[] {
                "InValidCase"})]
        public void DeleteActor(string uRL, string responseCode, string responseData, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DeleteActor"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("URL", uRL);
            argumentsOfScenario.Add("ResponseCode", responseCode);
            argumentsOfScenario.Add("ResponseData", responseData);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete Actor", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 77
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 78
 testRunner.Given("I am a client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 79
 testRunner.When(string.Format("I make DELETE Request \'{0}\'", uRL), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 80
 testRunner.Then(string.Format("response code must be \'{0}\'", responseCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 81
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
                ActorResourceFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ActorResourceFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
