Conforme a Regra de negócio do Desafio Nubank:

1 - Criei um Projeto Console no VISUAL STUDIO 2022 - CSHARP, NUBANK.SLN;

2 - Desenvolvi um menu de OPÇÃO, segue:

    Console.WriteLine("Operation: 1 - buy 2 - sell - 3 - Fim ");
    operation = Console.ReadLine();

    Nota: Se a opção for igual 3, finaliza a Operação;
    Caso opção diferente de 1,2 ou 3:
    Console.WriteLine("Opção Inválida !!!"), e break dentro de um loop.
    Sendo a opção 3, fecha o colchete da lista de entradas, saidas e
    GRAVA O ARQUIVO DE ENTRADAS JSON - INPUT.TXT NA PASTA ONDE SE
    ENCONTRA O APLICATIVO, NO MEU CASO:
    E:\projetos\Desafio\nubank\bin\Debug\net6.0
    CÓDIGO:
    string pastaAtual = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());

3 - Validar os campos de Entradas [unit_cost e quantity]:

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
        ............................................
 
4 - Classes:
    
    ClsCalculos media = new ClsCalculos();

5 - Teste Unitário.

    Da classe ClsCalculos:
    UnitTestNovaMediaPonderada
    UnitTestPoderadaAtual

6 - GIT
 