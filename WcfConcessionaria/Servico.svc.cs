using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfConcessionaria
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Servico : InterfaceServico
    {
        private BaseDados.DataDataContext dc = new BaseDados.DataDataContext();
        public void InsertFabricante(Modelo.Fabricante f)
        {
            if(f == null)
            {
                throw new ArgumentNullException("Fabricante Nulo");
            }

            dc.Fabricantes.InsertOnSubmit(new BaseDados.Fabricante { Id = f.Id, Descricao = f.Descricao});
            dc.SubmitChanges();
        }

        public void UpdateFabricante(Modelo.Fabricante f)
        {
            if (f == null)
            {
                throw new ArgumentNullException("Fabricante Nulo");
            }
            BaseDados.Fabricante f1 = (from x in dc.Fabricantes where x.Id == f.Id select x).Single();
            f1.Descricao = f.Descricao;
            dc.SubmitChanges();
        }

        public List<Modelo.Fabricante> SelectFabricante()
        {
            IQueryable objs = (from x in dc.Fabricantes select x);
            List<Modelo.Fabricante> fabrs = new List<Modelo.Fabricante>();
            foreach(BaseDados.Fabricante fabri in objs)
            {
                Modelo.Fabricante x = new Modelo.Fabricante
                {
                    Id = fabri.Id,
                    Descricao = fabri.Descricao
                };
                fabrs.Add(x);
            }
            return fabrs;
        }

        public void DeleteFabricante(Modelo.Fabricante f)
        {
            if(f==null)
            {
                throw new ArgumentNullException("Fabricante Nulo");
            }
            BaseDados.Fabricante f1 = (from x in dc.Fabricantes where x.Id == f.Id select x).Single();
            dc.Fabricantes.DeleteOnSubmit(f1);
            dc.SubmitChanges();
        }

        public void InsertVeiculo(Modelo.Veiculo v)
        {
            if(v==null)
            {
                throw new ArgumentNullException("Veiculo Nulo");
            }
            dc.Veiculos.InsertOnSubmit(new BaseDados.Veiculo { Id = v.Id, Ano = v.Ano, Modelo = v.Modelo, DataCompra = v.DataCompra, DataVenda = v.DataVenda, IdFabricante = v.IdFabricante, PrecoVenda = Convert.ToDecimal(v.PrecoVenda), ValorCompra = Convert.ToDecimal(v.ValorCompra), ValorVenda = Convert.ToDecimal(v.ValorVenda) });
            dc.SubmitChanges();
        }

        public void UpdateVeiculo(Modelo.Veiculo v)
        {
            if (v == null)
            {
                throw new ArgumentNullException("Veiculo Nulo");
            }

            BaseDados.Veiculo v1 = (from f in dc.Veiculos where f.Id == v.Id select f).Single();
            v1.Modelo = v.Modelo;
            v1.Ano = v.Ano;
            v1.IdFabricante = v.IdFabricante;
            dc.SubmitChanges();
        }

        public List<Modelo.Veiculo> SelectVeiculo()
        {
            IQueryable objs = (from x in dc.Veiculos select x);
            List<Modelo.Veiculo> veiculo = new List<Modelo.Veiculo>();
            foreach(BaseDados.Veiculo veiculos in objs)
            {
                Modelo.Veiculo x = new Modelo.Veiculo
                {
                    Id = veiculos.Id,
                    Modelo = veiculos.Modelo,
                    Ano = Convert.ToInt32(veiculos.Ano),
                    PrecoVenda = Convert.ToDouble(veiculos.PrecoVenda),
                    DataCompra = Convert.ToDateTime(veiculos.DataCompra),
                    ValorCompra = Convert.ToDouble(veiculos.ValorCompra),
                    ValorVenda = Convert.ToDouble(veiculos.ValorVenda),
                    DataVenda = Convert.ToDateTime(veiculos.DataVenda),
                    IdFabricante = Convert.ToInt32(veiculos.IdFabricante)

                };
                veiculo.Add(x);
            }
            return veiculo;
        }

        public void DeleteVeiculo(Modelo.Veiculo v)
        {
            if(v==null)
            {
                throw new ArgumentNullException("Veiculo Nulo");
            }

            BaseDados.Veiculo x = (from f in dc.Veiculos where f.Id == v.Id select f).Single();
            dc.Veiculos.DeleteOnSubmit(x);
            dc.SubmitChanges();
        }
    }
}
