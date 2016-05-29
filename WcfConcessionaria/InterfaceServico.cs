using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfConcessionaria
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface InterfaceServico
    {
        [OperationContract]
        void InsertFabricante(Modelo.Fabricante f);

        [OperationContract]
        void DeleteFabricante(Modelo.Fabricante f);

        [OperationContract]
        List<Modelo.Fabricante> SelectFabricante();

        [OperationContract]
        void UpdateFabricante(Modelo.Fabricante f);

        [OperationContract]
        void InsertVeiculo(Modelo.Veiculo v);

        [OperationContract]
        void DeleteVeiculo(Modelo.Veiculo v);

        [OperationContract]
        List<Modelo.Veiculo> SelectVeiculo();

        [OperationContract]
        void UpdateVeiculo(Modelo.Veiculo v);
        // TODO: Add your service operations here
    }
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
}
