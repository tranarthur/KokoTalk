using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFKokoTalks
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface KokoService
    {

        [OperationContract]
        Post[] GetPost(int profiletId);

        [OperationContract]
        void PushPost(string query);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Post
    {

        [DataMember]
        public string PostText
        {
            get;
            set;
        }

        [DataMember]
        public string PostTime
        {
            get;
            set;
        }
    }
}
