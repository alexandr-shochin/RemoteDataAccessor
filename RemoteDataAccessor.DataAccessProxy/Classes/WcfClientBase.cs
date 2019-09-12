using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using RemoteDataAccessor.Common.Interfaces.Settings;
using RemoteDataAccessor.Common.Interfaces.WcfContracts;

namespace RemoteDataAccessor.DataAccessProxy.Classes
{
    public class WcfClientBase<TRequestContract>
    {
        private readonly NetTcpBinding _netTcpBinding;
        private readonly EndpointAddress _endPoint;
        private readonly ChannelFactory<TRequestContract> _channel;

        private readonly TRequestContract _serverSessionContract;

        protected WcfClientBase(IDataAccessProxySettings dataAccessProxySettings)
        {
            _netTcpBinding = new NetTcpBinding(SecurityMode.None);

            foreach (IPEndPoint ipEndPoint in dataAccessProxySettings.IpEndPoints)
            {
                // TODO

                _endPoint = new EndpointAddress(new Uri($"net.tcp://{ipEndPoint.Address}:{ipEndPoint.Port}/{typeof(TRequestContract)}"));

                _channel = new ChannelFactory<TRequestContract>(_netTcpBinding);

                _serverSessionContract = _channel.CreateChannel(_endPoint);

                break;
            }
        }

        protected T ExecuteMethod<T>(Func<TRequestContract, T> method)
        {
            T result = default(T);

            try
            {
                result = method(_serverSessionContract);
            }
            /*Для ожидаемых исключений, т.е. исключений возникших на стороне WCF-сервиса и сгенерированных с помощью конструкции
             вида throw new FaultException<TException> методами, для которых в контракте сервиса указан FaultContract с соответствующим TException.*/
            catch (FaultException ex)
            {
                // TODO
                throw ex;
            }
            /*Для исключений связанных с превышением установленного времени выполнения метода.*/
            catch (TimeoutException ex)
            {
                // TODO
                throw ex;
            }
            /*Для исключений общего характера, которые могут произойти как на стороне клиента, так и на стороне сервера. К ним относятся, например,
             исключения возникающее при потере связи с сервисом или при превышении допустимого размера получаемого сообщения.*/
            catch (CommunicationException ex)
            {
                // TODO
                throw ex;
            }
            /*Для всех остальных исключений.*/
            catch (Exception ex)
            {
                // TODO
                throw ex;
            }

            return result;
        }
    }
}
