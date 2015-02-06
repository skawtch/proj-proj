using System.ServiceModel;

namespace ProjectTimesheet
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Person GetData(string id);
    }
}