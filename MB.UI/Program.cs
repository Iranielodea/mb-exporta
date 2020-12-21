﻿using MB.Dominio.Shared;
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
            string _tabela = "";
            string _acao = "";
            string _dataInicial = "";
            string _dataFinal = "";
            string _id = "0";

            //_tabela = "TRANSPORTADOR";
            //_tabela = "PEDIDO_ITEM";
            //string _tabela = "CLIENTE";
            //_acao = "EXPORTAR";
            //_id = "0";
            //string _dataInicial = "01.01.2015";
            //string _dataFinal = "10.01.2015";

            if (args.Count() > 0)
            {
                _tabela = args[0];
                _acao = args[1];
                _id = args[2];
                _dataInicial = args[3];
                _dataFinal = args[4];
            }

            if (_tabela.Trim() == "")
                return;

            int.TryParse(_id, out int id);
            EnTabela.TryParse(_tabela, out EnTabela enTabela);
            EnAcao.TryParse(_acao, out EnAcao enAcao);
            
            //enAcao = EnAcao.EXPORTAR;

            int tabela = (int)enTabela;

            //if (!string.IsNullOrWhiteSpace(_dataInicial))
            //    Console.WriteLine("Data Inicial informada");
            //else
            //    Console.WriteLine("Data Inicial não Informada");

            //Console.WriteLine("Tabela: " + _tabela);
            //Console.WriteLine("Acao: " + _acao);
            //Console.WriteLine("ID: " + _id);

            //Console.ReadKey();

            //return;

            if (_tabela.Trim() == "")
                return;

            if (_acao.Trim() == "")
                return;

            var session = new DalSession();

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
                            new FrontPedido().Exportar(session, enAcao, _dataInicial, _dataFinal, id);
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
                    case 14:
                        {
                            new FrontPedidoItem().Exportar(session, enAcao, _dataInicial, _dataFinal, id);
                            break;
                        }
                }
            }
            catch (System.Exception ex)
            {
                Funcoes.GravarArquivo("LogErro.txt", ex.Message);
            }
        }
    }
}
