using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nubank
{
    public class ClsCalculos
    {
        public ClsCalculos()
        {
           
        }

        public string Operacao { get; set; }
        public decimal Unit_cost { get; set; }
        public int Quantity { get; set; }
        public int Quantidadede_Acoes_Atual { get; set; }
        public int Quantidadede_Acoes_Compra { get; set; }
        public int Quantidadede_Acoes_Venda { get; set; }
        public decimal Total_Venda { get; set; }
        public decimal Preco_Venda { get; set; }
        public decimal Preco_Atual_Compra { get; set; }

         public decimal GetMedia_Ponderada_Atual(decimal preco_Atual_Compra,decimal quantidadede_Acoes_Atual, 
            decimal quantidadede_Acoes_Compra, decimal quantidadede_Acoes_Venda)

        {
            decimal media_Ponderada_Atual = ((preco_Atual_Compra * quantidadede_Acoes_Atual) + 
                (quantidadede_Acoes_Atual * preco_Atual_Compra)) / (quantidadede_Acoes_Compra + quantidadede_Acoes_Venda);
            //                               ((preco_Atual_Compra * quantidadede_Acoes_Atual) + (quantidadede_Acoes_Atual * preco_Atual_Compra)) / (quantidadede_Acoes_Compra + quantidadede_Acoes_Venda);     
            return media_Ponderada_Atual;
        }

        public decimal GetNova_Media_Ponderada(decimal quantidadede_Acoes_Atual, decimal ponderada_Atual, decimal preco_Atual_Compra,
                                                  decimal quantidadede_Acoes_Compra)

        {
            decimal nova_Media_Ponderada = ((quantidadede_Acoes_Atual * ponderada_Atual) + (quantidadede_Acoes_Compra +
                preco_Atual_Compra)) / (quantidadede_Acoes_Atual + quantidadede_Acoes_Compra); 
 
                   return nova_Media_Ponderada;
        }


        
    }
}