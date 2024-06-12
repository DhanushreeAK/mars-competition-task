using FluentAssertions.Equivalency.Tracing;
using Newtonsoft.Json;
using System;
using static Microsoft.VisualStudio.Services.Graph.GraphResourceIds;


namespace Mars_CompetitionTask_US2.TestData
{
    public class EducationData
    {
        public string college { get; set; }
        public string country { get; set; }
        public string title { get; set; }

        public string degree { get; set; }

        public string graduationYear { get; set; }
    }
    /*
   public class ReadAndParseJsonFileWithNewtonsoftJson
   {
       private readonly string _sampleJsonFilePath;
       public ReadAndParseJsonFileWithNewtonsoftJson(string sampleJsonFilePath)
       {
           _sampleJsonFilePath = sampleJsonFilePath;
       }
   }

   public List<EducationData> UseUserDefinedObjectWithNewtonsoftJson
   {
       get
       {
           using StreamReader reader = new("./EducationTestData.json");
           var json = reader.ReadToEnd();
           List<EducationData> education = JsonConvert.DeserializeObject<List<EducationData>>(json);
           return education;
       }
   }
   */
}
