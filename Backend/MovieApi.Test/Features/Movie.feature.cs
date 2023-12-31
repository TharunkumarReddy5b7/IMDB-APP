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
    public partial class MovieResourceFeature : object, Xunit.IClassFixture<MovieResourceFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Movie.feature"
#line hidden
        
        public MovieResourceFeature(MovieResourceFeature.FixtureData fixtureData, MovieApi_Test_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Movie Resource", null, ProgrammingLanguage.CSharp, featureTags);
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
        
        [Xunit.SkippableTheoryAttribute(DisplayName="GetAll Movies")]
        [Xunit.TraitAttribute("FeatureTitle", "Movie Resource")]
        [Xunit.TraitAttribute("Description", "GetAll Movies")]
        [Xunit.TraitAttribute("Category", "GetAllMovies")]
        [Xunit.InlineDataAttribute("movies", "200", @"[{""id"":1,""name"":""RRR"",""yearOfRelease"":2018,""plot"":""Story Movie"",""actors"":[{""id"":1,""name"":""Prabhas"",""bio"":""Good Actor"",""dob"":""12-12-1998 00:00:00"",""gender"":""Male""},{""id"":2,""name"":""Rana"",""bio"":""PowerStar"",""dob"":""12-12-1998 00:00:00"",""gender"":""Male""}],""genres"":[{""id"":1,""name"":""Action""}],""coverImage"":""Link"",""producer"":{""id"":1,""name"":""Shobu"",""bio"":""Good Producer"",""dob"":""12-12-1998 00:00:00"",""gender"":""Male""}},{""id"":2,""name"":""Robo"",""yearOfRelease"":2019,""plot"":""Technical Movie"",""actors"":[{""id"":1,""name"":""Prabhas"",""bio"":""Good Actor"",""dob"":""12-12-1998 00:00:00"",""gender"":""Male""},{""id"":2,""name"":""Rana"",""bio"":""PowerStar"",""dob"":""12-12-1998 00:00:00"",""gender"":""Male""}],""genres"":[{""id"":2,""name"":""Drama""}],""coverImage"":""Link"",""producer"":{""id"":1,""name"":""Shobu"",""bio"":""Good Producer"",""dob"":""12-12-1998 00:00:00"",""gender"":""Male""}}]", new string[0])]
        public void GetAllMovies(string uRL, string responseCode, string responseData, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GetAllMovies"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("URL", uRL);
            argumentsOfScenario.Add("ResponseCode", responseCode);
            argumentsOfScenario.Add("ResponseData", responseData);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("GetAll Movies", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Get Movie By Id")]
        [Xunit.TraitAttribute("FeatureTitle", "Movie Resource")]
        [Xunit.TraitAttribute("Description", "Get Movie By Id")]
        [Xunit.TraitAttribute("Category", "GetMovieById")]
        [Xunit.InlineDataAttribute("movies/1", "200", @"{""id"":1,""name"":""RRR"",""yearOfRelease"":2018,""plot"":""Story Movie"",""actors"":[{""id"":1,""name"":""Prabhas"",""bio"":""Good Actor"",""dob"":""12-12-1998 00:00:00"",""gender"":""Male""},{""id"":2,""name"":""Rana"",""bio"":""PowerStar"",""dob"":""12-12-1998 00:00:00"",""gender"":""Male""}],""genres"":[{""id"":1,""name"":""Action""}],""coverImage"":""Link"",""producer"":{""id"":1,""name"":""Shobu"",""bio"":""Good Producer"",""dob"":""12-12-1998 00:00:00"",""gender"":""Male""}}", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("movies/2", "200", @"{""id"":2,""name"":""Robo"",""yearOfRelease"":2019,""plot"":""Technical Movie"",""actors"":[{""id"":1,""name"":""Prabhas"",""bio"":""Good Actor"",""dob"":""12-12-1998 00:00:00"",""gender"":""Male""},{""id"":2,""name"":""Rana"",""bio"":""PowerStar"",""dob"":""12-12-1998 00:00:00"",""gender"":""Male""}],""genres"":[{""id"":2,""name"":""Drama""}],""coverImage"":""Link"",""producer"":{""id"":1,""name"":""Shobu"",""bio"":""Good Producer"",""dob"":""12-12-1998 00:00:00"",""gender"":""Male""}}", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("movies/20", "404", "Movie with Id 20 not found", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("movies/-1", "404", "Invalid MovieId", new string[] {
                "InvalidCase"})]
        public void GetMovieById(string uRL, string responseCode, string responseData, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GetMovieById"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("URL", uRL);
            argumentsOfScenario.Add("ResponseCode", responseCode);
            argumentsOfScenario.Add("ResponseData", responseData);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Movie By Id", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Create Movie")]
        [Xunit.TraitAttribute("FeatureTitle", "Movie Resource")]
        [Xunit.TraitAttribute("Description", "Create Movie")]
        [Xunit.TraitAttribute("Category", "CreateMovie")]
        [Xunit.InlineDataAttribute("movies", "{\"name\":\"Bahubali\",\"YearOfRelease\":2009,\"Plot\":\"Epic Movie\",\"ProducerId\":2,\"Actor" +
            "ids\":[2],\"CoverImage\":\"url\",\"Genreids\":[1]}", "201", "Movie successfully created", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("movies", "{\"name\":\"\",\"YearOfRelease\":2009,\"Plot\":\"Epic Movie\",\"ProducerId\":2,\"Actorids\":[2]" +
            ",\"CoverImage\":\"url\",\"Genreids\":[1]}", "400", "Movie name can not be null or empty", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("movies", "{\"name\":\"Bahubali\",\"YearOfRelease\":0,\"Plot\":\"Epic Movie\",\"ProducerId\":2,\"Actorids" +
            "\":[2],\"CoverImage\":\"url\",\"Genreids\":[1]}", "400", "Enter valid year", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("movies", "{\"name\":\"Bahubali\",\"YearOfRelease\":2009,\"Plot\":\"\",\"ProducerId\":2,\"Actorids\":[2],\"" +
            "CoverImage\":\"url\",\"Genreids\":[1]}", "400", "Plot can not be empty", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("movies", "{\"name\":\"Bahubali\",\"YearOfRelease\":2009,\"Plot\":\"Epic Movie\",\"ProducerId\":2,\"Actor" +
            "ids\":[],\"CoverImage\":\"url\",\"Genreids\":[1]}", "400", "please enter atleast one actorid", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("movies", "{\"name\":\"Bahubali\",\"YearOfRelease\":2009,\"Plot\":\"Epic Movie\",\"ProducerId\":2,\"Actor" +
            "ids\":[2],\"CoverImage\":\"url\",\"Genreids\":[]}", "400", "please enter atleast one Genreid", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("movies", "{\"name\":\"Bahubali\",\"YearOfRelease\":2009,\"Plot\":\"Epic Movie\",\"ProducerId\":2,\"Actor" +
            "ids\":[2],\"CoverImage\":\"\",\"Genreids\":[1]}", "400", "cover image cannot be empty", new string[] {
                "InvalidCase"})]
        public void CreateMovie(string uRL, string requestData, string responseCode, string responseData, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CreateMovie"};
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
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Movie", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 33
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 34
 testRunner.Given("I am a client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 35
 testRunner.When(string.Format("I am make POST Request \'{0}\' with the following data \'{1}\'", uRL, requestData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 36
 testRunner.Then(string.Format("response code must be \'{0}\'", responseCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 37
 testRunner.And(string.Format("response data must look like \'{0}\'", responseData), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Update Movie")]
        [Xunit.TraitAttribute("FeatureTitle", "Movie Resource")]
        [Xunit.TraitAttribute("Description", "Update Movie")]
        [Xunit.TraitAttribute("Category", "UpdateMovie")]
        [Xunit.InlineDataAttribute("movies/1", "{\"name\":\"Bahubali\",\"YearOfRelease\":2009,\"Plot\":\"Epic Movie\",\"ProducerId\":2,\"Actor" +
            "ids\":[2],\"CoverImage\":\"url\",\"Genreids\":[1]}", "200", "Movie updated successfully", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("movies/1", "{\"name\":\"\",\"YearOfRelease\":2009,\"Plot\":\"Epic Movie\",\"ProducerId\":2,\"Actorids\":[2]" +
            ",\"CoverImage\":\"url\",\"Genreids\":[1]}", "400", "Movie name can not be null or empty", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("movies/1", "{\"name\":\"Bahubali\",\"YearOfRelease\":0,\"Plot\":\"Epic Movie\",\"ProducerId\":2,\"Actorids" +
            "\":[2],\"CoverImage\":\"url\",\"Genreids\":[1]}", "400", "Enter valid year", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("movies/1", "{\"name\":\"Bahubali\",\"YearOfRelease\":2009,\"Plot\":\"\",\"ProducerId\":2,\"Actorids\":[2],\"" +
            "CoverImage\":\"url\",\"Genreids\":[1]}", "400", "Plot can not be empty", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("movies/1", "{\"name\":\"Bahubali\",\"YearOfRelease\":2009,\"Plot\":\"Epic Movie\",\"ProducerId\":2,\"Actor" +
            "ids\":[],\"CoverImage\":\"url\",\"Genreids\":[1]}", "400", "please enter atleast one actorid", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("movies/1", "{\"name\":\"Bahubali\",\"YearOfRelease\":2009,\"Plot\":\"Epic Movie\",\"ProducerId\":2,\"Actor" +
            "ids\":[2],\"CoverImage\":\"url\",\"Genreids\":[]}", "400", "please enter atleast one Genreid", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("movies/1", "{\"name\":\"Bahubali\",\"YearOfRelease\":2009,\"Plot\":\"Epic Movie\",\"ProducerId\":2,\"Actor" +
            "ids\":[2],\"CoverImage\":\"\",\"Genreids\":[1]}", "400", "cover image cannot be empty", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("movies/20", "{\"name\":\"Bahubali\",\"YearOfRelease\":2009,\"Plot\":\"Epic Movie\",\"ProducerId\":2,\"Actor" +
            "ids\":[2],\"CoverImage\":\"url\",\"Genreids\":[1]}", "400", "Movie with Id 20 not found", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("movies/-1", "{\"name\":\"Bahubali\",\"YearOfRelease\":2009,\"Plot\":\"Epic Movie\",\"ProducerId\":2,\"Actor" +
            "ids\":[2],\"CoverImage\":\"url\",\"Genreids\":[1]}", "400", "Invalid MovieId", new string[] {
                "InvalidCase"})]
        public void UpdateMovie(string uRL, string requestData, string responseCode, string responseData, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "UpdateMovie"};
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
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update Movie", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Delete Movie")]
        [Xunit.TraitAttribute("FeatureTitle", "Movie Resource")]
        [Xunit.TraitAttribute("Description", "Delete Movie")]
        [Xunit.TraitAttribute("Category", "DeleteMovie")]
        [Xunit.InlineDataAttribute("movies/1", "200", "Movie Deleted Successfully", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("movies/2", "200", "Movie Deleted Successfully", new string[] {
                "ValidCase"})]
        [Xunit.InlineDataAttribute("movies/-1", "400", "Invalid MovieId", new string[] {
                "InvalidCase"})]
        [Xunit.InlineDataAttribute("movies/34", "400", "Movie with Id 34 not found", new string[] {
                "InvalidCase"})]
        public void DeleteMovie(string uRL, string responseCode, string responseData, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DeleteMovie"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("URL", uRL);
            argumentsOfScenario.Add("ResponseCode", responseCode);
            argumentsOfScenario.Add("ResponseData", responseData);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete Movie", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 80
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 81
 testRunner.Given("I am a client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 82
 testRunner.When(string.Format("I make DELETE Request \'{0}\'", uRL), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 83
 testRunner.Then(string.Format("response code must be \'{0}\'", responseCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 84
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
                MovieResourceFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                MovieResourceFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
