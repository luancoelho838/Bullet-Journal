//Modelo para Bullet Journal em C# .NET 10.0


/*
* 1. Melhorar retorno/passagem de dados entre funções => OK
2. Validar entradas com TryParse => OK
3. Melhorar a apresentação do resumo => OK
4. Permitir edição das informações antes do resumo final 
5. Persistir os registros
6. Pensar em classes e orientação a objetos
*/

List<string> metas = new List<string>();
List<string> tarefas = new List<string>();



InformarHorario();
ApresentarDiario();
DefinirMetas();
EditarMetas(); 
DefinirTarefas();
TimeSpan horasDeSono = CalcularHorasDeSono();
string seuDia = ComoFoiSeuDia();

MensagemPreRelatorio();

Thread.Sleep(2000);

ResumoDoDia(horasDeSono, seuDia);



void InformarHorario()
{
    Console.WriteLine(DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy"));
}

void ApresentarDiario()
{
    Console.WriteLine("\n==================================================");
    Console.WriteLine("\t\tBULLET JOURNAL");
    Console.WriteLine("==================================================\n");
}

void DefinirMetas()
{
    Console.WriteLine("Deseja adicionar quantas metas para este mês?\n");
    int quantidadeMetas = int.Parse(Console.ReadLine());
    Console.WriteLine("\nInsira suas metas para o mês:\n");
    for (int i = 0; i < quantidadeMetas; i++)
    {
        MetasMes();
    }
}

void MetasMes()
{
    metas.Add(Console.ReadLine());
}

void EditarMetas()
{
    Console.WriteLine("\n---------- EDITAR METAS ----------\n");

    for (int i = 0; i < metas.Count; i++)
    {
        Console.WriteLine($"{i + 1} - {metas[i]}");
    }

    Console.WriteLine("\nQual meta deseja editar?");
    bool resultado = int.TryParse(Console.ReadLine(), out int opcao);

    while (!resultado || opcao < 1 || opcao > metas.Count)
    {
        Console.WriteLine("Por favor, insira um número válido.");
        resultado = int.TryParse(Console.ReadLine(), out opcao);
    }

    int indice = opcao - 1;

    Console.WriteLine("Digite a nova meta:");
    metas[indice] = Console.ReadLine();
}


void DefinirTarefas()
{
    Console.WriteLine("\nDeseja adicionar quantas tarefas diárias?\n");

    bool resultado = int.TryParse(Console.ReadLine(), out int quantidadeTarefas);

    while(!resultado){
        Console.WriteLine("Por favor, insira um número válido.");
        resultado = int.TryParse(Console.ReadLine(), out quantidadeTarefas);
    }
    
        Console.WriteLine("\nInsira suas tarefas diárias:\n");
        for (int i = 0; i < quantidadeTarefas; i++)
        {
            TarefasDiarias();
        }
}

void TarefasDiarias()
{
    tarefas.Add(Console.ReadLine());
}


TimeSpan CalcularHorasDeSono()
{
    Console.WriteLine("\nInsira o horário que você acordou (HH:mm): ");
    bool resultadoAcordou = DateTime.TryParse(Console.ReadLine(), out DateTime horarioAcordou);

    while(!resultadoAcordou){
    Console.WriteLine("Por favor, insira um horário válido.");
    resultadoAcordou = DateTime.TryParse(Console.ReadLine(), out horarioAcordou);
}

    Console.WriteLine("\nInsira o horário que você dormiu (HH:mm): ");
    bool resultadoDormiu = DateTime.TryParse(Console.ReadLine(), out DateTime horarioDormiu);

    while (!resultadoDormiu)
    {
        Console.WriteLine("Por favor, insira um horário válido.");
        resultadoDormiu = DateTime.TryParse(Console.ReadLine(), out horarioDormiu);
    }

    TimeSpan horasDeSono = horarioAcordou - horarioDormiu;

    if (horasDeSono.TotalHours < 0)
    {
        horasDeSono = horasDeSono.Add(TimeSpan.FromDays(1));
    }


    return horasDeSono;
}

string ComoFoiSeuDia()
{
    Console.WriteLine("\nComo foi seu dia?\n");
    return Console.ReadLine();  
}

void MensagemPreRelatorio()
{
    Console.WriteLine("\n\nQue dia produtivo!");
    Console.WriteLine("\nGerando relatório do seu dia...\n");
}

void ResumoDoDia(TimeSpan horasDeSono, string seuDia)
{
    Console.WriteLine("==================================================");
    Console.WriteLine("\t\tRESUMO DO DIA");
    Console.WriteLine("==================================================");

    Console.WriteLine("\n---------- METAS DO MÊS ----------");
    for (int i = 0; i < metas.Count; i++)
    {
        Console.WriteLine($" - {metas[i]}");
    }


    Console.WriteLine("\n---------- TAREFAS DIÁRIAS ----------");
    for (int i = 0; i < tarefas.Count; i++)
    {
        Console.WriteLine($" - {tarefas[i]}");
    }

    Console.WriteLine("\n---------- HORAS DE SONO ----------");
    Console.WriteLine($"\nHoras de sono: {horasDeSono.Hours}h {horasDeSono.Minutes}min\n");

    Console.WriteLine("\n---------- COMO FOI SEU DIA ----------");
    Console.WriteLine($"\n{seuDia}\n");

    Console.WriteLine("==================================================");
    Console.WriteLine("\t\tFIM DO RESUMO");
    Console.WriteLine("==================================================");
}

