using System;
using System.ServiceModel.Web;

namespace ProjectTimesheet
{
    public class Service1 : IService1
    {
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "data/{id}")]
        public Person GetData(string id)
        {
            projectFile f = new projectFile();
            int x = 0;
            return new Person()
            {
                Id = Convert.ToInt32(id),
                Name = "Michael Blake codin away over here"
            };
        }
    }
    // do public class Project / Task / etc go here?
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}