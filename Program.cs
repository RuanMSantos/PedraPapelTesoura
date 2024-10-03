int numeroPlayer = 0;
string resposta = "";
int pontuacaoMaquina = 0;
int pontuacaoPlayer = 0;
int NumeroMaquina = 0;
string vencedor = "";
 
Loop();
void Loop(){
 
    Tela();
    Maquina();
    Comparador();
    if (pontuacaoPlayer < 5 && pontuacaoMaquina < 5){
        Loop();
    }
    else if (pontuacaoPlayer == 5){
        Pontuacao();
        vencedor = "Você ganhou";
    }
    else {
        Pontuacao();
        vencedor = "Você perdeu";
    }
}
Console.WriteLine($"{vencedor}");
void Tela(){
    Pontuacao();
    Console.WriteLine("0. Pedra 1. Papel 2. Tesoura");
    resposta = Console.ReadLine()!;
    if (!int.TryParse(resposta, out numeroPlayer)){
        Console.WriteLine("Impossível converter, tente novamente...");
        Console.ReadKey();
        Tela();
    }
    else if (numeroPlayer < 0 || numeroPlayer > 2){
        Console.WriteLine("Numero incorreto, tente novamente...");
        Console.ReadKey();
        Tela();
    }
}
void Maquina(){
    int random = new Random().Next(0, 3);
    NumeroMaquina = random;
}
void Comparador()
{
    if (numeroPlayer == 0 && NumeroMaquina == 1){
        pontuacaoMaquina++;
        Console.WriteLine("\nPonto da máquina");
        Thread.Sleep(500);
    }
    else if (numeroPlayer == 0 && NumeroMaquina == 2){
        pontuacaoPlayer++;
        Console.WriteLine("\nPonto do jogador");
        Thread.Sleep(500);
    }
    else if (numeroPlayer == 1 && NumeroMaquina == 0){
        pontuacaoPlayer++;
        Console.WriteLine("\nPonto do jogador");
        Thread.Sleep(500);
    }
    else if (numeroPlayer == 1 && NumeroMaquina == 2){
        pontuacaoMaquina++;
        Console.WriteLine("\nPonto da máquina");
        Thread.Sleep(500);
    }
    else if (numeroPlayer == 2 && NumeroMaquina == 0){
        pontuacaoMaquina++;
        Console.WriteLine("\nPonto da máquina");
        Thread.Sleep(500);
    }
    else if (numeroPlayer == 2 && NumeroMaquina == 1){
        pontuacaoPlayer++;
        Console.WriteLine("\nPonto do jogador");
        Thread.Sleep(500);
    }
    else {
        Console.WriteLine("\nEmpate");
        Thread.Sleep(500);
    }
}
void Pontuacao(){
    Console.Clear();
    Console.WriteLine("=> Pedra - Papel - Tesoursa <=\n");
    Console.WriteLine($"Pontuação Máquina: {pontuacaoMaquina}");
    Console.WriteLine($"Pontuação Player: {pontuacaoPlayer}\n");
}