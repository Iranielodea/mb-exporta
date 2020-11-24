using MB.Infra.DataBase;
using MB.UI.Enumerador;
using MB.UI.Front;
using System;
using System.Linq;

namespace MB.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            string _tabela = "TRANSPORTADOR";
            //string _tabela = "CLIENTE";
            string _acao = "EXPORTAR";
            string _id = "0";

            if (args.Count() > 0)
            {
                _tabela = args[0];
                _acao = args[1];
                _id = args[2];
            }

            int.TryParse(_id, out int id);
            EnTabela.TryParse(_tabela, out EnTabela enTabela);
            EnAcao.TryParse(_acao, out EnAcao enAcao);

            var session = new DalSession();
            //enAcao = EnAcao.EXPORTAR;

            int tabela = (int)enTabela;

            try
            {
                switch (tabela)
                {
                    case 2:
                        {
                            new FrontCidade().Exportar(session, enAcao, id);
                            break;
                        }
                    case 3:
                        {
                            new FrontEstado().Exportar(session, enAcao, id);
                            break;
                        }
                    case 4:
                        {
                            new FrontEmpresa().Exportar(session, enAcao, id);
                            break;
                        }
                    case 5:
                        {
                            new FrontCliente().Exportar(session, enAcao, id);
                            break;
                        }
                    case 6:
                        {
                            new FrontFornecedor().Exportar(session, enAcao, id);
                            break;
                        }
                    case 7:
                        {
                            new FrontGrupo().Exportar(session, enAcao, id);
                            break;
                        }
                    case 8:
                        {
                            new FrontPedido().Exportar(session, enAcao, id);
                            break;
                        }
                    case 9:
                        {
                            new FrontProduto().Exportar(session, enAcao, id);
                            break;
                        }
                    case 10:
                        {
                            new FrontTransportadora().Exportar(session, enAcao, id);
                            break;
                        }
                    case 11:
                        {
                            new FrontUnidade().Exportar(session, enAcao, id);
                            break;
                        }
                    case 12:
                        {
                            new FrontVendedor().Exportar(session, enAcao, id);
                            break;
                        }
                    case 13:
                        {
                            new FrontUsuario().Exportar(session, enAcao, id);
                            break;
                        }
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
                //Console.WriteLine(ex.Message);
            }
            Console.WriteLine("----------- Fim --------------");
            Console.ReadKey();

        }
    }
}
