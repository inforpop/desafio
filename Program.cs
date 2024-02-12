using System.Text.Json;
using System.Text;
using nubank;
 
using var ms = new MemoryStream();
using var writer = new Utf8JsonWriter(ms);

Console.WriteLine("Compra e Venda de Ações");
string operacao = "oi";
decimal quantidadede_Acoes_Atual = 0;
decimal quantidadede_Acoes_Compra = 0;
decimal erro = 0;
decimal media_Ponderada_Atual=0;
string operation;
string unit_cost;
string quantity;
decimal unit;
int i = 1;
string taxaImposto;
decimal imposto = 0;
decimal total_Compras = 0;
decimal total_Vendas = 0;
decimal valor_Venda_Atual = 0;
decimal imposto_Pago = 0;
decimal preco_Atual_Compra = 0;
decimal preco_Venda = 0;
decimal quantidadede_Acoes_Venda = 0;
decimal lucro = 0;
decimal prejuizo = 0;
decimal ponderada_Compra_Atual = 0;
decimal nova_Media_Ponderada   = 0;
StringBuilder sb = new StringBuilder();
StringBuilder saidas = new StringBuilder();
saidas.Append("[");
while (true) 
{
    ClsCalculos media = new ClsCalculos();
    Console.WriteLine("ID da Operação = " + i.ToString());

    Console.WriteLine("Operation: 1 - buy 2 - sell - 3 - Fim ");
    operation = Console.ReadLine();
    if (operation == "1")
    {
        Console.WriteLine("Compra de Ações");
        operacao = "buy";
    }
    else if (operation == "2")
    {
        Console.WriteLine("Venda de Ações");
        operacao = "sell";
    }
    else if (operation == "3")
    {
        Console.WriteLine("Fim da Operação");
        //ultima linha vazia
      
        sb.Append(" {}]");
        saidas.Append("]");
        //Salva o Arquivo INPUT.TXT na pasta onde EXECUTAR o projeto =  ...\nubank\bin\Debug\net6.0 
        string curDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
        
        System.IO.File.WriteAllText(@"input.txt", sb.ToString());
        Console.WriteLine(curDir);
        Console.WriteLine("Operação de Compra e Venda de Ações:");
        Console.WriteLine($"{sb.ToString()}");
        Console.ReadLine();
        
        Console.WriteLine($"{saidas.ToString()}");
        Console.ReadLine();

        break;
    }
    else if (operation != "1" || operation != "2" || operation != "3")
    {
        Console.WriteLine("Opção Inválida !!!");

        break;
    }

    Console.WriteLine("Preço Unitário:");
    unit_cost = Console.ReadLine();
    
    try
    {
        unit = Decimal.Parse(unit_cost);
    }

    catch (Exception ex)
    {
        Console.WriteLine("Valor Unitário Inválido !!!");
        Console.ReadLine();
        break;
    }


    unit = Decimal.Parse(unit_cost);

    Console.WriteLine("Quantidade:");
    quantity = Console.ReadLine();

    try
    {
        erro = Decimal.Parse(quantity);
    }

    catch (Exception ex)
    {
        Console.WriteLine("Quantidade Inválida !!!");
        Console.ReadLine();
        break;
    }
    unit = Decimal.Parse(quantity);
    //gravar json
   
    if (i == 1)
    {
        
        sb.Append("[{\"operation\": " + " "+operacao + ", \"unit_cost\":" + unit_cost + ", \"quantity\":" + quantity + "},\n");
        
       
        

    }
    if (i > 1)
    {
        sb.Append(" {\"operation\": " + " "+operacao + ", \"unit_cost\":" + unit_cost + ", \"quantity\":" + quantity + "},\n");
        
    }
     
    Console.WriteLine("Operação de Compra e Venda de Ações:");
    Console.WriteLine($"{sb.ToString()}");
    Console.ReadLine();
    

    //fim gravar json se a Opção = 3

    if (operation == "1")
    {
        quantidadede_Acoes_Atual += Int32.Parse(quantity);
        quantidadede_Acoes_Compra = Int32.Parse(quantity);
        preco_Atual_Compra = Decimal.Parse(unit_cost);
        lucro = Decimal.Parse(unit_cost) * quantidadede_Acoes_Atual;
        saidas.Append("{\"tax\": " + " " + imposto + "}");
    }
    if (operation == "2")
    {
        quantidadede_Acoes_Atual -= Int32.Parse(quantity.ToString());
        total_Vendas = Decimal.Parse(unit_cost) * (Int32.Parse(quantity));
        preco_Venda = Decimal.Parse(unit_cost);
        quantidadede_Acoes_Venda = Int32.Parse(quantity);
    }
    //Só se for compra
    if (operation == "1")
    {
        total_Compras = Decimal.Parse(unit_cost) * (Int32.Parse(quantity));
         
        ponderada_Compra_Atual = media.GetMedia_Ponderada_Atual(preco_Atual_Compra, quantidadede_Acoes_Atual,
                                                                        quantidadede_Acoes_Compra, quantidadede_Acoes_Venda);
               
       media_Ponderada_Atual = ((preco_Atual_Compra * quantidadede_Acoes_Atual) + (quantidadede_Acoes_Atual * preco_Atual_Compra)) / (quantidadede_Acoes_Compra + quantidadede_Acoes_Venda);

       nova_Media_Ponderada = media.GetNova_Media_Ponderada(quantidadede_Acoes_Atual, ponderada_Compra_Atual, preco_Atual_Compra,
                                      quantidadede_Acoes_Compra);

              
        Console.WriteLine("Nova Média Ponderada         -> " + Math.Round(nova_Media_Ponderada + 1));
        
    }
        
    i++;

    decimal calculoImposto = preco_Venda * quantidadede_Acoes_Venda;

    if (calculoImposto > 20000)
    {
        taxaImposto = "20";
        if (operation == "2")
        {
            if (preco_Venda > preco_Atual_Compra)
            {
                lucro = preco_Atual_Compra * quantidadede_Acoes_Venda;
            }
            ///lucro = total_Vendas / Math.Round(nova_Media_Ponderada); 
            decimal desconto = 0;
            if (preco_Venda < preco_Atual_Compra)
            {
                
                prejuizo = (preco_Venda - preco_Atual_Compra) * quantidadede_Acoes_Atual;
            }

            if (preco_Venda < ponderada_Compra_Atual)
            {
                prejuizo = preco_Venda * quantidadede_Acoes_Venda;
            }
            if (preco_Venda > ponderada_Compra_Atual) 
            {
                //media poderada = 15 - caso 5
                if (nova_Media_Ponderada > 14 && nova_Media_Ponderada <= 15) 
                {
                    lucro = 0;
                    prejuizo = 0;
                }

                desconto = lucro- prejuizo;
     
                imposto = desconto * Decimal.Parse(taxaImposto) / 100;

                imposto_Pago = imposto - desconto;
            
                Console.WriteLine("Imposto                = " + imposto.ToString());
                Console.WriteLine("Desconto da Operação   = " + desconto.ToString());
            }
            //caso 6 tirar -prejuizo
            imposto = (lucro-prejuizo) * Decimal.Parse(taxaImposto) / 100;
            if (preco_Venda < preco_Atual_Compra)
            {
                imposto = 0;
            }
             
                saidas.Append("{\"tax\": " + " " + imposto + "}");
            Console.WriteLine($"{saidas.ToString()}");
            Console.ReadLine();
            Console.WriteLine("Imposto                = " + imposto.ToString());
            Console.WriteLine("Desconto da Operação   = " + desconto.ToString());
            Console.WriteLine("Nova média ponderada   = " + ponderada_Compra_Atual.ToString());
        }
              
        if (quantidadede_Acoes_Atual <= 0)
        {
            imposto_Pago = 0;
        }
        if (preco_Venda < ponderada_Compra_Atual)//colocar a nova media ponderada -> nova_Media_Ponderada
        {
         
            imposto_Pago = 0;

        }

         
        Console.WriteLine("Açõe Disponíveis       = " + quantidadede_Acoes_Atual);
        Console.WriteLine("Prejuizo               = " + prejuizo);
        Console.WriteLine("Lucro                  = " + lucro);
    }
    else
    {
        Console.WriteLine("Sem Imposto a Pagar!!!");
    }
 }

