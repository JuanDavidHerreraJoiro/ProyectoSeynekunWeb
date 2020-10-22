using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class CosteoGeneralRepository
    {
        private IList<CosteoGeneral> lista;
        private string ruta = "CosteoGeneral.txt";
        SqlConnection Connection;
        SqlCommand command;
        public CosteoGeneralRepository(ConnectionManager connectionManager)
        {
            Connection = connectionManager.connection;
            command = new SqlCommand();
            lista = new List<CosteoGeneral>();
        }
        public void Guardar(CosteoGeneral costeoGeneral)
        {
            using (var command = Connection.CreateCommand())
            {

                command.CommandText = "INSERT INTO CosteoGeneral(CodioCosteoGeneral,NumeroUnidades,MateriaPrimaCOP,ManoDeObraCOP," +
                                          "CostosIndirectosDeFabricacionCOP,TotalCostosProuduccionCOP,GastosGeneralesCOP,TotalCostoProductoCOP,"+
                                          "ComisionCOP,UtilidadDeseadaCOP,PrecioVentaSinGastosCOP,PrecioVentaConGastosCOP,PrecioReferenciaDelMercadoCOP,"+
                                          "MateriaPrimaSobreElCosto,MateriaPrimaSobreLasVentas,ManoDeObraSobreElCosto,ManoDeObraSobreLasVentas,CostosIndirectosDeFabricacionSobreElCosto,"+
                                          "CostosIndirectosDeFabricacionSobreLasVentas,TotalCostosProduccionSobreElCosto,TotalCostosProduccionSobreLasVentas,GastosGeneralesSobreElCosto,"+
                                          "GastosGeneralesSobreLasVentas,TotalCostoProductoSobreElCosto,TotalCostoProductoSobreLasVentas,ComisionSobreLasVentas,UtilidadDeseadaLasVentas,"+
                                          "PrecioSinGastosSobreLasVentas,PrecioConGastosSobreLasVentas,MateriaPrimaUSD,ManoDeObraUSD,CostosIndirectosDeFabricacionUSD,TotalCostosProuduccionUSD,"+
                                          "GastosGeneralesUSD,TotalCostoProductoUSD,ComisionUSD,UtilidadDeseadaUSD,PrecioVentaSinGastosUSD,PrecioVentaConGastosUSD,PrecioReferenciaDelMercadoUSD,"+
                                          "ValorTRM,OP,CodigoParametroReferencia)"+
                                          "values" +
                                          "(Next value for seq_CosteoGeneral,@NumeroUnidades,@MateriaPrimaCOP,@ManoDeObraCOP,@CostosIndirectosDeFabricacionCOP,@TotalCostosProuduccionCOP," +
                                          "@GastosGeneralesCOP,@TotalCostoProductoCOP,@ComisionCOP,@UtilidadDeseadaCOP,@PrecioVentaSinGastosCOP,@PrecioVentaConGastosCOP,"+
                                          "@PrecioReferenciaDelMercadoCOP,@MateriaPrimaSobreElCosto,@MateriaPrimaSobreLasVentas,@ManoDeObraSobreElCosto,@ManoDeObraSobreLasVentas,"+
                                          "@CostosIndirectosDeFabricacionSobreElCosto,@CostosIndirectosDeFabricacionSobreLasVentas,@TotalCostosProduccionSobreElCosto,"+
                                          "@TotalCostosProduccionSobreLasVentas,@GastosGeneralesSobreElCosto,@GastosGeneralesSobreLasVentas,@TotalCostoProductoSobreElCosto,"+
                                          "@TotalCostoProductoSobreLasVentas,@ComisionSobreLasVentas,@UtilidadDeseadaLasVentas,@PrecioSinGastosSobreLasVentas,@PrecioConGastosSobreLasVentas,"+
                                          "@MateriaPrimaUSD,@ManoDeObraUSD,@CostosIndirectosDeFabricacionUSD,@TotalCostosProuduccionUSD,@GastosGeneralesUSD,@TotalCostoProductoUSD,"+
                                          "@ComisionUSD,@UtilidadDeseadaUSD,@PrecioVentaSinGastosUSD,@PrecioVentaConGastosUSD,@PrecioReferenciaDelMercadoUSD,@ValorTRM,@OP,@CodigoParametroReferencia)";

                //command.Parameters.AddWithValue("@CodioCosteoGeneral", costeoGeneral.CosteoGeneralPK);
                command.Parameters.AddWithValue("@NumeroUnidades", costeoGeneral.NumeroUnidades);
                command.Parameters.AddWithValue("@MateriaPrimaCOP", costeoGeneral.MateriaPrimaCOP);
                command.Parameters.AddWithValue("@ManoDeObraCOP", costeoGeneral.ManoDeObraCOP);
                command.Parameters.AddWithValue("@CostosIndirectosDeFabricacionCOP", costeoGeneral.CostosIndirectosDeFabricacionCOP);
                command.Parameters.AddWithValue("@TotalCostosProuduccionCOP", costeoGeneral.TotalCostosProuduccionCOP);
                command.Parameters.AddWithValue("@GastosGeneralesCOP", costeoGeneral.GastosGeneralesCOP);
                command.Parameters.AddWithValue("@TotalCostoProductoCOP", costeoGeneral.TotalCostoProductoCOP);
                command.Parameters.AddWithValue("@ComisionCOP", costeoGeneral.ComisionCOP);
                command.Parameters.AddWithValue("@UtilidadDeseadaCOP", costeoGeneral.UtilidadDeseadaCOP);
                command.Parameters.AddWithValue("@PrecioVentaSinGastosCOP", costeoGeneral.PrecioVentaSinGastosCOP);
                command.Parameters.AddWithValue("@PrecioVentaConGastosCOP", costeoGeneral.PrecioVentaConGastosCOP);
                command.Parameters.AddWithValue("@PrecioReferenciaDelMercadoCOP", costeoGeneral.PrecioReferenciaDelMercadoCOP);
                command.Parameters.AddWithValue("@MateriaPrimaSobreElCosto", costeoGeneral.MateriaPrimaSobreElCosto);
                command.Parameters.AddWithValue("@MateriaPrimaSobreLasVentas", costeoGeneral.MateriaPrimaSobreLasVentas);
                command.Parameters.AddWithValue("@ManoDeObraSobreElCosto", costeoGeneral.ManoDeObraSobreElCosto);
                command.Parameters.AddWithValue("@ManoDeObraSobreLasVentas", costeoGeneral.ManoDeObraSobreLasVentas);
                command.Parameters.AddWithValue("@CostosIndirectosDeFabricacionSobreElCosto", costeoGeneral.CostosIndirectosDeFabricacionSobreElCosto);
                command.Parameters.AddWithValue("@CostosIndirectosDeFabricacionSobreLasVentas", costeoGeneral.CostosIndirectosDeFabricacionSobreLasVentas);
                command.Parameters.AddWithValue("@TotalCostosProduccionSobreElCosto", costeoGeneral.TotalCostosProduccionSobreElCosto);
                command.Parameters.AddWithValue("@TotalCostosProduccionSobreLasVentas", costeoGeneral.TotalCostosProduccionSobreLasVentas);
                command.Parameters.AddWithValue("@GastosGeneralesSobreElCosto", costeoGeneral.GastosGeneralesSobreElCosto);
                command.Parameters.AddWithValue("@GastosGeneralesSobreLasVentas", costeoGeneral.GastosGeneralesSobreLasVentas);
                command.Parameters.AddWithValue("@TotalCostoProductoSobreElCosto", costeoGeneral.TotalCostoProductoSobreElCosto);
                command.Parameters.AddWithValue("@TotalCostoProductoSobreLasVentas", costeoGeneral.TotalCostoProductoSobreLasVentas);
                command.Parameters.AddWithValue("@ComisionSobreLasVentas", costeoGeneral.ComisionSobreLasVentas);
                command.Parameters.AddWithValue("@UtilidadDeseadaLasVentas", costeoGeneral.UtilidadDeseadaLasVentas);
                command.Parameters.AddWithValue("@PrecioSinGastosSobreLasVentas", costeoGeneral.PrecioSinGastosSobreLasVentas);
                command.Parameters.AddWithValue("@PrecioConGastosSobreLasVentas", costeoGeneral.PrecioConGastosSobreLasVentas);
                command.Parameters.AddWithValue("@MateriaPrimaUSD", costeoGeneral.MateriaPrimaUSD);
                command.Parameters.AddWithValue("@ManoDeObraUSD", costeoGeneral.ManoDeObraUSD);
                command.Parameters.AddWithValue("@CostosIndirectosDeFabricacionUSD", costeoGeneral.CostosIndirectosDeFabricacionUSD);
                command.Parameters.AddWithValue("@TotalCostosProuduccionUSD", costeoGeneral.TotalCostosProuduccionUSD);
                command.Parameters.AddWithValue("@GastosGeneralesUSD", costeoGeneral.GastosGeneralesUSD);
                command.Parameters.AddWithValue("@TotalCostoProductoUSD", costeoGeneral.TotalCostoProductoUSD);
                command.Parameters.AddWithValue("@ComisionUSD", costeoGeneral.ComisionUSD);
                command.Parameters.AddWithValue("@UtilidadDeseadaUSD", costeoGeneral.UtilidadDeseadaUSD);
                command.Parameters.AddWithValue("@PrecioVentaSinGastosUSD", costeoGeneral.PrecioVentaSinGastosUSD);
                command.Parameters.AddWithValue("@PrecioVentaConGastosUSD", costeoGeneral.PrecioVentaConGastosUSD);
                command.Parameters.AddWithValue("@PrecioReferenciaDelMercadoUSD", costeoGeneral.PrecioReferenciaDelMercadoUSD);
                command.Parameters.AddWithValue("@ValorTRM", costeoGeneral.Trm.ValorTrm);
                command.Parameters.AddWithValue("@OP", costeoGeneral.Op);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", costeoGeneral.ParametrosDeReferencia.Codigo);
                command.ExecuteNonQuery();
            }
        }
        public IList<CosteoGeneral> ConsultarTodos()
        {
            lista.Clear();
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = @"SELECT CG.NumeroUnidades,CG.MateriaPrimaCOP,CG.ManoDeObraCOP,CG.CostosIndirectosDeFabricacionCOP,
                    CG.TotalCostosProuduccionCOP,CG.GastosGeneralesCOP,CG.TotalCostoProductoCOP,CG.ComisionCOP,CG.UtilidadDeseadaCOP,CG.PrecioVentaSinGastosCOP,
                    CG.PrecioVentaConGastosCOP,CG.PrecioReferenciaDelMercadoCOP,CG.MateriaPrimaSobreElCosto,CG.MateriaPrimaSobreLasVentas,CG.ManoDeObraSobreElCosto,
                    CG.ManoDeObraSobreLasVentas,CG.CostosIndirectosDeFabricacionSobreElCosto,CG.CostosIndirectosDeFabricacionSobreLasVentas,CG.TotalCostosProduccionSobreElCosto,
                    CG.TotalCostosProduccionSobreLasVentas,CG.GastosGeneralesSobreElCosto,CG.GastosGeneralesSobreLasVentas,CG.TotalCostoProductoSobreElCosto,CG.TotalCostoProductoSobreLasVentas,
                    CG.ComisionSobreLasVentas,CG.UtilidadDeseadaLasVentas,CG.PrecioSinGastosSobreLasVentas,CG.PrecioConGastosSobreLasVentas,CG.MateriaPrimaUSD,CG.ManoDeObraUSD,CG.CostosIndirectosDeFabricacionUSD,
                    CG.TotalCostosProuduccionUSD,CG.GastosGeneralesUSD,CG.TotalCostoProductoUSD,CG.ComisionUSD,CG.UtilidadDeseadaUSD,CG.PrecioVentaSinGastosUSD,CG.PrecioVentaConGastosUSD,CG.PrecioReferenciaDelMercadoUSD,
                    CG.ValorTRM,CG.OP,PR.ProductoExportar,PR.PresentacionProducto,PR.Codigo FROM CosteoGeneral CG JOIN ParametrosReferencia PR
                    ON CG.CodigoParametroReferencia = PR.Codigo";

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    CosteoGeneral costeoGeneral = Mapear(dataReader);
                    lista.Add(costeoGeneral);
                }
            }
            return lista;
        }

        private CosteoGeneral Mapear(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            CosteoGeneral costeoGeneral = new CosteoGeneral();

            
            costeoGeneral.NumeroUnidades = dataReader.GetDecimal(0);
            costeoGeneral.MateriaPrimaCOP = dataReader.GetDecimal(1);
            costeoGeneral.ManoDeObraCOP = dataReader.GetDecimal(2);
            costeoGeneral.CostosIndirectosDeFabricacionCOP = dataReader.GetDecimal(3);
            costeoGeneral.TotalCostosProuduccionCOP = dataReader.GetDecimal(4);
            costeoGeneral.GastosGeneralesCOP = dataReader.GetDecimal(5);
            costeoGeneral.TotalCostoProductoCOP = dataReader.GetDecimal(6);
            costeoGeneral.ComisionCOP = dataReader.GetDecimal(7);
            costeoGeneral.UtilidadDeseadaCOP = dataReader.GetDecimal(8);
            costeoGeneral.PrecioVentaSinGastosCOP = dataReader.GetDecimal(9);
            costeoGeneral.PrecioVentaConGastosCOP = dataReader.GetDecimal(10);
            costeoGeneral.PrecioReferenciaDelMercadoCOP = dataReader.GetDecimal(11);
            costeoGeneral.MateriaPrimaSobreElCosto = dataReader.GetDecimal(12);
            costeoGeneral.MateriaPrimaSobreLasVentas = dataReader.GetDecimal(13);
            costeoGeneral.ManoDeObraSobreElCosto = dataReader.GetDecimal(14);
            costeoGeneral.ManoDeObraSobreLasVentas = dataReader.GetDecimal(15);
            costeoGeneral.CostosIndirectosDeFabricacionSobreElCosto = dataReader.GetDecimal(16);
            costeoGeneral.CostosIndirectosDeFabricacionSobreLasVentas = dataReader.GetDecimal(17);
            costeoGeneral.TotalCostosProduccionSobreElCosto = dataReader.GetDecimal(18);
            costeoGeneral.TotalCostosProduccionSobreLasVentas = dataReader.GetDecimal(19);
            costeoGeneral.GastosGeneralesSobreElCosto = dataReader.GetDecimal(20);
            costeoGeneral.GastosGeneralesSobreLasVentas = dataReader.GetDecimal(21);
            costeoGeneral.TotalCostoProductoSobreElCosto = dataReader.GetDecimal(22);
            costeoGeneral.TotalCostoProductoSobreLasVentas = dataReader.GetDecimal(23);
            costeoGeneral.ComisionSobreLasVentas = dataReader.GetDecimal(24);
            costeoGeneral.UtilidadDeseadaLasVentas = dataReader.GetDecimal(25);
            costeoGeneral.PrecioSinGastosSobreLasVentas = dataReader.GetDecimal(26);
            costeoGeneral.PrecioConGastosSobreLasVentas = dataReader.GetDecimal(27);
            costeoGeneral.MateriaPrimaUSD = dataReader.GetDecimal(28);
            costeoGeneral.ManoDeObraUSD = dataReader.GetDecimal(29);
            costeoGeneral.CostosIndirectosDeFabricacionUSD = dataReader.GetDecimal(30);
            costeoGeneral.TotalCostosProuduccionUSD = dataReader.GetDecimal(31);
            costeoGeneral.GastosGeneralesUSD = dataReader.GetDecimal(32);
            costeoGeneral.TotalCostoProductoUSD = dataReader.GetDecimal(33);
            costeoGeneral.ComisionUSD = dataReader.GetDecimal(34);
            costeoGeneral.UtilidadDeseadaUSD = dataReader.GetDecimal(35);
            costeoGeneral.PrecioVentaSinGastosUSD = dataReader.GetDecimal(36);
            costeoGeneral.PrecioVentaConGastosUSD = dataReader.GetDecimal(37);
            costeoGeneral.PrecioReferenciaDelMercadoUSD = dataReader.GetDecimal(38);
            costeoGeneral.Trm.ValorTrm = dataReader.GetDecimal(39);
            costeoGeneral.Op = dataReader.GetDecimal(40);
            costeoGeneral.ParametrosDeReferencia.ProductoExportar = dataReader.GetString(41);
            costeoGeneral.ParametrosDeReferencia.PresentacionProducto = dataReader.GetDouble(42);
            costeoGeneral.ParametrosDeReferencia.Codigo = dataReader.GetString(43);

            return costeoGeneral;
        }

        public void Modificar(CosteoGeneral costeoGeneral)
        {
            using (var command = Connection.CreateCommand())
            {

                command.CommandText = "UPDATE CosteoGeneral SET " +
                                          "CodioCosteoGeneral=Next value for seq_CosteoGeneral," +
                                          "NumeroUnidades=@NumeroUnidades," +
                                          "MateriaPrimaCOP=@MateriaPrimaCOP," +
                                          "ManoDeObraCOP=@ManoDeObraCOP," +
                                          "CostosIndirectosDeFabricacionCOP=@CostosIndirectosDeFabricacionCOP," +
                                          "TotalCostosProuduccionCOP=@TotalCostosProuduccionCOP," +
                                          "GastosGeneralesCOP=@GastosGeneralesCOP," +
                                          "TotalCostoProductoCOP=@TotalCostoProductoCOP," +
                                          "ComisionCOP=@ComisionCOP," +
                                          "UtilidadDeseadaCOP=@UtilidadDeseadaCOP," +
                                          "PrecioVentaSinGastosCOP=@PrecioVentaSinGastosCOP," +
                                          "PrecioVentaConGastosCOP=@PrecioVentaConGastosCOP," +
                                          "PrecioReferenciaDelMercadoCOP=@PrecioReferenciaDelMercadoCOP," +
                                          "MateriaPrimaSobreElCosto=@MateriaPrimaSobreElCosto," +
                                          "MateriaPrimaSobreLasVentas=@MateriaPrimaSobreLasVentas," +
                                          "ManoDeObraSobreElCosto=@ManoDeObraSobreElCosto," +
                                          "ManoDeObraSobreLasVentas=@ManoDeObraSobreLasVentas," +
                                          "CostosIndirectosDeFabricacionSobreElCosto=@CostosIndirectosDeFabricacionSobreElCosto," +
                                          "CostosIndirectosDeFabricacionSobreLasVentas=@CostosIndirectosDeFabricacionSobreLasVentas," +
                                          "TotalCostosProduccionSobreElCosto=@TotalCostosProduccionSobreElCosto," +
                                          "TotalCostosProduccionSobreLasVentas=@TotalCostosProduccionSobreLasVentas," +
                                          "GastosGeneralesSobreElCosto=@GastosGeneralesSobreElCosto," +
                                          "GastosGeneralesSobreLasVentas=@GastosGeneralesSobreLasVentas," +
                                          "TotalCostoProductoSobreElCosto=@TotalCostoProductoSobreElCosto," +
                                          "TotalCostoProductoSobreLasVentas=@TotalCostoProductoSobreLasVentas," +
                                          "ComisionSobreLasVentas=@ComisionSobreLasVentas," +
                                          "UtilidadDeseadaLasVentas=@UtilidadDeseadaLasVentas," +
                                          "PrecioSinGastosSobreLasVentas=@PrecioSinGastosSobreLasVentas," +
                                          "PrecioConGastosSobreLasVentas=@PrecioConGastosSobreLasVentas," +
                                          "MateriaPrimaUSD=@MateriaPrimaUSD," +
                                          "ManoDeObraUSD=@ManoDeObraUSD," +
                                          "CostosIndirectosDeFabricacionUSD=@CostosIndirectosDeFabricacionUSD," +
                                          "TotalCostosProuduccionUSD=@TotalCostosProuduccionUSD," +
                                          "GastosGeneralesUSD=@GastosGeneralesUSD," +
                                          "TotalCostoProductoUSD=@TotalCostoProductoUSD," +
                                          "ComisionUSD=@ComisionUSD," +
                                          "UtilidadDeseadaUSD=@UtilidadDeseadaUSD," +
                                          "PrecioVentaSinGastosUSD=@PrecioVentaSinGastosUSD," +
                                          "PrecioVentaConGastosUSD=@PrecioVentaConGastosUSD," +
                                          "PrecioReferenciaDelMercadoUSD=@PrecioReferenciaDelMercadoUSD," +
                                          "ValorTRM=@ValorTRM," +
                                          "OP=@OP," +
                                          "CodigoParametroReferencia=@CodigoParametroReferencia " +
                                          "WHERE CodigoParametroReferencia=@CodigoParametroReferencia";


                //command.Parameters.AddWithValue("@CodioCosteoGeneral", costeoGeneral.CosteoGeneralPK);
                command.Parameters.AddWithValue("@NumeroUnidades", costeoGeneral.NumeroUnidades);
                command.Parameters.AddWithValue("@MateriaPrimaCOP", costeoGeneral.MateriaPrimaCOP);
                command.Parameters.AddWithValue("@ManoDeObraCOP", costeoGeneral.ManoDeObraCOP);
                command.Parameters.AddWithValue("@CostosIndirectosDeFabricacionCOP", costeoGeneral.CostosIndirectosDeFabricacionCOP);
                command.Parameters.AddWithValue("@TotalCostosProuduccionCOP", costeoGeneral.TotalCostosProuduccionCOP);
                command.Parameters.AddWithValue("@GastosGeneralesCOP", costeoGeneral.GastosGeneralesCOP);
                command.Parameters.AddWithValue("@TotalCostoProductoCOP", costeoGeneral.TotalCostoProductoCOP);
                command.Parameters.AddWithValue("@ComisionCOP", costeoGeneral.ComisionCOP);
                command.Parameters.AddWithValue("@UtilidadDeseadaCOP", costeoGeneral.UtilidadDeseadaCOP);
                command.Parameters.AddWithValue("@PrecioVentaSinGastosCOP", costeoGeneral.PrecioVentaSinGastosCOP);
                command.Parameters.AddWithValue("@PrecioVentaConGastosCOP", costeoGeneral.PrecioVentaConGastosCOP);
                command.Parameters.AddWithValue("@PrecioReferenciaDelMercadoCOP", costeoGeneral.PrecioReferenciaDelMercadoCOP);
                command.Parameters.AddWithValue("@MateriaPrimaSobreElCosto", costeoGeneral.MateriaPrimaSobreElCosto);
                command.Parameters.AddWithValue("@MateriaPrimaSobreLasVentas", costeoGeneral.MateriaPrimaSobreLasVentas);
                command.Parameters.AddWithValue("@ManoDeObraSobreElCosto", costeoGeneral.ManoDeObraSobreElCosto);
                command.Parameters.AddWithValue("@ManoDeObraSobreLasVentas", costeoGeneral.ManoDeObraSobreLasVentas);
                command.Parameters.AddWithValue("@CostosIndirectosDeFabricacionSobreElCosto", costeoGeneral.CostosIndirectosDeFabricacionSobreElCosto);
                command.Parameters.AddWithValue("@CostosIndirectosDeFabricacionSobreLasVentas", costeoGeneral.CostosIndirectosDeFabricacionSobreLasVentas);
                command.Parameters.AddWithValue("@TotalCostosProduccionSobreElCosto", costeoGeneral.TotalCostosProduccionSobreElCosto);
                command.Parameters.AddWithValue("@TotalCostosProduccionSobreLasVentas", costeoGeneral.TotalCostosProduccionSobreLasVentas);
                command.Parameters.AddWithValue("@GastosGeneralesSobreElCosto", costeoGeneral.GastosGeneralesSobreElCosto);
                command.Parameters.AddWithValue("@GastosGeneralesSobreLasVentas", costeoGeneral.GastosGeneralesSobreLasVentas);
                command.Parameters.AddWithValue("@TotalCostoProductoSobreElCosto", costeoGeneral.TotalCostoProductoSobreElCosto);
                command.Parameters.AddWithValue("@TotalCostoProductoSobreLasVentas", costeoGeneral.TotalCostoProductoSobreLasVentas);
                command.Parameters.AddWithValue("@ComisionSobreLasVentas", costeoGeneral.ComisionSobreLasVentas);
                command.Parameters.AddWithValue("@UtilidadDeseadaLasVentas", costeoGeneral.UtilidadDeseadaLasVentas);
                command.Parameters.AddWithValue("@PrecioSinGastosSobreLasVentas", costeoGeneral.PrecioSinGastosSobreLasVentas);
                command.Parameters.AddWithValue("@PrecioConGastosSobreLasVentas", costeoGeneral.PrecioConGastosSobreLasVentas);
                command.Parameters.AddWithValue("@MateriaPrimaUSD", costeoGeneral.MateriaPrimaUSD);
                command.Parameters.AddWithValue("@ManoDeObraUSD", costeoGeneral.ManoDeObraUSD);
                command.Parameters.AddWithValue("@CostosIndirectosDeFabricacionUSD", costeoGeneral.CostosIndirectosDeFabricacionUSD);
                command.Parameters.AddWithValue("@TotalCostosProuduccionUSD", costeoGeneral.TotalCostosProuduccionUSD);
                command.Parameters.AddWithValue("@GastosGeneralesUSD", costeoGeneral.GastosGeneralesUSD);
                command.Parameters.AddWithValue("@TotalCostoProductoUSD", costeoGeneral.TotalCostoProductoUSD);
                command.Parameters.AddWithValue("@ComisionUSD", costeoGeneral.ComisionUSD);
                command.Parameters.AddWithValue("@UtilidadDeseadaUSD", costeoGeneral.UtilidadDeseadaUSD);
                command.Parameters.AddWithValue("@PrecioVentaSinGastosUSD", costeoGeneral.PrecioVentaSinGastosUSD);
                command.Parameters.AddWithValue("@PrecioVentaConGastosUSD", costeoGeneral.PrecioVentaConGastosUSD);
                command.Parameters.AddWithValue("@PrecioReferenciaDelMercadoUSD", costeoGeneral.PrecioReferenciaDelMercadoUSD);
                command.Parameters.AddWithValue("@ValorTRM", costeoGeneral.Trm.ValorTrm);
                command.Parameters.AddWithValue("@OP", costeoGeneral.Op);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", costeoGeneral.ParametrosDeReferencia.Codigo);
                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(string codigoParametro)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM CosteoGeneral WHERE CodigoParametroReferencia=@CodigoParametroReferencia";
                command.Parameters.AddWithValue("@CodigoParametroReferencia", codigoParametro);
                command.ExecuteNonQuery();
            }
        }
        

        public double Contar(string codigo)
        {
            IList<CosteoGeneral> clientes = ConsultarTodos();
            return clientes.Where(i => i.ParametrosDeReferencia.Codigo.ToUpper().Trim().Contains(codigo.ToUpper())).Count();
        }
        public double ContarCosteo(string codigo)
        {
            IList<CosteoGeneral> clientes = ConsultarTodos();
            return clientes.Where(i => i.ParametrosDeReferencia.Codigo.ToUpper().Trim().Equals(codigo.ToUpper())).Count();
        }
        public List<CosteoGeneral> ConsultarTodo()
        {
            IList<CosteoGeneral> clientes = ConsultarTodos();
            return clientes.ToList();
        }
        public List<CosteoGeneral> ConsultarCodigo(string filtro)
        {
            IList<CosteoGeneral> clientes = ConsultarTodos();
            return clientes.Where(i => i.ParametrosDeReferencia.Codigo.ToUpper().Trim().Contains(filtro.ToUpper())).ToList();
        }
        public List<CosteoGeneral> ConsultaIndividual(string codigo)
        {
            IList<CosteoGeneral> clientes = ConsultarTodos();
            return clientes.Where(i => i.ParametrosDeReferencia.Codigo.ToUpper().Trim().Equals(codigo.ToUpper())).ToList();
        }
    }
}
